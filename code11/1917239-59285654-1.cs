    private readonly PaymentGatewayResolver _paymentGatewayResolver;
    public OrderService(PaymentGatewayResolver paymentGatewayResolver)
    {
        this._paymentGatewayResolver = paymentGatewayResolver; 
    }
    public DoOrder(E_PaymentGatewayType paymentGatewayType)
    {
        IPaymentGateway paymentGateway = this._paymentGatewayResolver(paymentGatewayType);
        paymentGateway.Pay();
    }
