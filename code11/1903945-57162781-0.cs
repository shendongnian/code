    public abstract class Bank
    {
        public abstract string Country { get; } // Everything inheriting must implement it
        public virtual decimal TaxPercent { get { return 0.25; } } // Implementing it is optional
        public decimal DeclareTaxes()
        {
            decimal taxesToPay = 4000 * TaxPercent;
            return taxesToPay;
        }
    }
    
    public sealed class BahamasBank
    {
        public override string Country { get { return "Bahamas"; }
        public override TaxPercent { get { return 0.0; } } // Bahamas is different from most countries in tax related stuff
    }
    public sealed class CanadaBank
    {
        public override string Country { get { return "Canada"; }
    }
