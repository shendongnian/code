    public interface IPaymentGateway<T> where T : class
    {
        string Name { get; }
        T CreatePaymentRequest(PaymentRequest request);
        PaymentResponse ProcessPaymentResponse(T response);
    }
    public class PayPal<T> : IPaymentGateway<T> where T : class
    {
        public string Name { get; }
        public T CreatePaymentRequest(PaymentRequest request)
        {
            throw new NotImplementedException();
        }
        public PaymentResponse ProcessPaymentResponse(T response)
        {
            throw new NotImplementedException();
        }
    }
    public class Example
    {
        public void ExampleMethod()
        {
            IPaymentGateway<Foo> paypal = new PayPal<Foo>();
            var name = paypal.Name;
            Foo paymentRequest = paypal.CreatePaymentRequest(new PaymentRequest());
            var paymentResponse = paypal.ProcessPaymentResponse(new Foo());
        }
    }
    public class Foo
    {
    }
    public class PaymentResponse
    {
    }
    public class PaymentRequest
    {
    }
