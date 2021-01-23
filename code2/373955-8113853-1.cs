    public abstract class Voucher
    {
        public bool isValid(ShoppingCart sc);
        public string FailureMessage { get { return "This voucher does not apply"; } }
        // ...
    }
    public class DiscountVoucher : Voucher
    {
        private decimal Threshold;
        public override bool isValid(ShoppingCart sc)
        {
            return (sc.total >= Threshold);
        }
        public override string FailureMessage
        {
            get { return FormatString("Please spend £{0} to use this discount", Threshold); }
        }
    
