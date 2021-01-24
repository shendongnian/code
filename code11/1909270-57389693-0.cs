    public class PaymentService<TResponse> : IPaymentService<TResponse>
    {
        public IPaymentDetails PaymentDetails { get; set; }
        public IPaymentProcessor PaymentProcessor { get; set; }
    
        public PaymentService(IPaymentDetails paymentDetails)
        {
            PaymentDetails = paymentDetails;
            PaymentProcessor = PaymentStrategy.GetPaymentType(paymentDetails);
        }
    
        public TResponse Process()
        {
            return PaymentProcessor.Process(PaymentDetails); 
        }
           
    
    }
