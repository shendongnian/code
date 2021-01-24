    public class DepositAssembly
    {
        public string VoucherNo { get; set; }
        // In DDD the following fields would be capsulated into a "Money" value-object
        public string Currency {get;set;} // The type of currency, eg.: GBP
        public double Total { get; set; } // The amount of the deposit
    }
