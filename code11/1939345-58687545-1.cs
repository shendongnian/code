    internal class Program
    {
        public static void Main(string[] args)
        {
            var reason = ReasonConstant.Reason.NotEnoughStock.GetReasonInfo(ReasonData);
        }
    }
    public static class ReasonUtils
    {
        public static ReasonInfo GetReasonInfo(this ReasonConstant.Reason reason, Dictionary<ReasonConstant.Reason, ReasonInfo> reasonData)
        {
            if (reasonData == null)
                return null;
            if (!reasonData.ContainsKey(reason))
                return null;
            else
                return reasonData[reason];
        }
    }
    
    public class ReasonInfo
    {
        public bool IsValid { get; set; }
        public string Responsability { get; set; }
        public string Text { get; set; }
    }
    
    public static class ReasonConstant
    {
        public enum Reason
        {
            NotEnoughStock, // Valid = yes, Responsability = company, Text = There is not enough stock
            ProductNotAvailabe, // Valid = no, Responsability = company, Text = Produc is not available
            PaymentNotDone, // Valid = no, Responsability = client, Text = Payment is not done
            BlackListedClient, // Valid = no, Responsability = client, Text = Client is black listed
            NotEnoughTime // Valid = yes, Responsability = company, Text = There is not enough time
        }
    }
