    public abstract class Voucher
    {
        public int Id { get; set; }
        public decimal Value { get; protected set; }
        public const string SuccessMessage = "Applied";
        public decimal Threshold { get { return 0.0; } }
        public string FailureMessage { get { return ""; } }
    }
