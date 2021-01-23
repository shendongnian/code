    void Main()
    {
        var adjustments = new Adjustment[]
        {
            new CompoundTaxAdjustment(7M),
            new NonCompoundTaxAdjustment(3M),
            new CompoundTaxAdjustment(5M)
        };
        
        var original = 100M;
        
        var formula = Adjustment.GenerateFormula(adjustments);
        
        var result = formula.Forward(original).Dump(); // prints 115,5
        var newOriginal = formula.Backward(result).Dump(); // prints 100
    }
    
    public abstract class Adjustment
    {
        public class Formula
        {
            public decimal Factor = 1.0M;
            public decimal Offset;
            
            public decimal Forward(decimal input)
            {
                return input * Factor + Offset;
            }
            
            public decimal Backward(decimal input)
            {
                return (input - Offset) / Factor;
            }
        }
        
        public static Formula GenerateFormula(IEnumerable<Adjustment> adjustments)
        {
            Formula formula = new Formula();
            foreach (var adjustment in adjustments)
                adjustment.Adjust(formula);
            return formula;
        }
        
        protected abstract void Adjust(Formula formula);
    }
    
    public class FlatValueAdjustment : Adjustment
    {
        private decimal _Value;
        
        public FlatValueAdjustment(decimal value)
        {
            _Value = value;
        }
    
        protected override void Adjust(Formula formula)
        {
            formula.Offset += _Value;
        }
    }
    
    public abstract class TaxAdjustment : Adjustment
    {
        protected TaxAdjustment(decimal percentage)
        {
            Percentage = percentage;
        }
        
        protected decimal Percentage
        {
            get;
            private set;
        }
    }
    
    public class CompoundTaxAdjustment : TaxAdjustment
    {
        public CompoundTaxAdjustment(decimal percentage)
            : base(percentage)
        {
        }
    
        protected override void Adjust(Formula formula)
        {
            var myFactor = 1M + Percentage / 100M;
            formula.Offset *= myFactor;
            formula.Factor *= myFactor;
        }
    }
    
    public class NonCompoundTaxAdjustment : TaxAdjustment
    {
        public NonCompoundTaxAdjustment(decimal percentage)
            : base(percentage)
        {
        }
    
        protected override void Adjust(Formula formula)
        {
            formula.Factor += (Percentage / 100M);
        }
    }
