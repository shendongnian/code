    using Autofac;
    using Autofac.Builder;
    using Autofac.Core;
    using Autofac.Features.Scanning;
    public static class AutoFacExtensions
    {
        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle>
            AsClosedTypesOf<TLimit, TScanningActivatorData, TRegistrationStyle>(
                this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
                Type openGenericServiceType,
                object key)
            where TScanningActivatorData : ScanningActivatorData
        {
            if (openGenericServiceType == null) throw new ArgumentNullException("openGenericServiceType");
            return registration.As(t => 
                new[] { t }
                .Concat(t.GetInterfaces())
                .Where(i => i.IsClosedTypeOf(openGenericServiceType))
                .Select(i => new KeyedService(key, i)));
        }
    } 
