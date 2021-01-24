    public class OrderService
    {
        private readonly IPaymentGatewayFactory _factory;
        public void DoOrder(bool isFoo)
        {
            var service = _factory.Create(isFoo);
            this._service.Pay();
        }
    }
