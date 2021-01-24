    public class PaymentAdapter : IPayment
    {
        public PaymentAdapter(PaymentGatewayFoo foo, PaymentGatewayBoo boo) {...}
        public void Pay(bool isFoo)
        {
            var service = isFoo ? this.foo : this.boo;
            service.Pay();
        }
    }
