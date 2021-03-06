using Microsoft.Extensions.DependencyInjection.Extensions;
using SimpleCaptcha;
using SimpleCaptcha.Storage;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CaptchaBuilderExtensions
    {
        public static ICaptchaBuilder AddConfiguration(this ICaptchaBuilder builder, Action<CaptchaOptions> configureOptions)
        {
            builder.Services.Configure(configureOptions);
            return builder;
        }

        public static ICaptchaBuilder UseMemoryStore(this ICaptchaBuilder builder)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped<IStorage, MemoryStorage>());
            return builder;
        }

        public static ICaptchaBuilder UseDistributedStore(this ICaptchaBuilder builder)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped<IStorage, DistributedStorage>());
            return builder;
        }
    }
}
