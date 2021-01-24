    services.AddTransient<PaymentGatewayResolver>(serviceProvider => key =>
    {
        switch (key)
        {
            case E_PaymentGatewayType.Foo:
                return serviceProvider.GetService<PaymentGatewayFoo>();
            case E_PaymentGatewayType.Boo:
                return serviceProvider.GetService<PaymentGatewayBoo>();
            case E_PaymentGatewayType.Undefined:
                default:
                throw new NotSupportedException($"PaymentGatewayRepositoryResolver, key: {key}");
        }
    });
