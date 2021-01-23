    public abstract class PaymentSummary
    {
      public string _summary;
      public string _type;
    }
    public class xPaymentSummary : PaymentSummary
    {
      public xPaymentSummary() { }
      public xPaymentSummary(string summary)
      {
         _summary = summary;
         _type = this.GetType().ToString();
      }
    }
