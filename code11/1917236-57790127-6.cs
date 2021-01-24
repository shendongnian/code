    public class OrderService
    {
        private readonly IPayment _payment;
        public void DoOrder(bool isFoo)
        {
            _payment.Pay(isFoo);
        }
    }
