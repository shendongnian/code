    namespace PaymentGateway.Core.Abstractions {
    
        public interface IPaymentGateway
        {
    
            string Name { get; }
    
            T CreatePaymentRequest<T>(PaymentRequest request);
    
            PaymentResponse ProcessPaymentResponse<T>(T response);
    
        } 
    }
