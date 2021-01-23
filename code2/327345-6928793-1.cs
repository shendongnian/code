    public enum PaymentType { Other, DD, Cash, Card }
    
    public class DDmembersmonthlyreport
    {
        ...
        public PaymentType paymenttype;
        // Edit
        public void UpdatePaymentType(string fromCombobox)
        {
            paymenttype = (PaymentType)Enum.Parse(typeof(PaymentType), fromCombobox);
        }
    }
