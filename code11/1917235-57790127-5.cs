    public class PaymentGatewayFactory : IPaymentGatewayFactory 
    {
        public PaymentGatewayFactory(PaymentGatewayFoo foo, PaymentGatewayBoo boo) {...}
        public IPaymentGateway Create(bool isFoo) =>
            isFoo ? this.foo : this.boo;
    }
