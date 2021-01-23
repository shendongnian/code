    public class BaseSurchargePolicy {
        protected abstract double BasePremium { get; }
        protected abstract double FixedDeductibleSurchargePercent { get; }
        public double FixedDeductibleSurchageAmount{
          get
          {
            return (BasePremium * FixedDeductibleSurchargePercent);
          }
        }
        protected ICollection<string> _ProcessorsUsed;
        public IEnumerable<string> ProcessorsUsed 
        { 
          get { return ProcessorsUsed; }
        }
    }
    
    public class OldSurchargePolicy : BaseSurchargePolicy 
    {
    
        protected double BasePremium 
        { 
            _ProcessorsUsed.Add(GetType().Name);
            return CollisionPremium + TheftPremium; 
        }
        protected double FixedDeductibleSurchargePercent { get; set; }
    
        public double CollisionPremium { get; set; }
        public double TheftPremium { get; set; }
    }
    
    public class MedicalSurchargeDecorator: BaseSurchargePolicy
    {
        private BaseSurchargePolicy _wrapped;
        private double _medicalPremium;
        public MedicalSurchargeDecorator(BaseSurchargePolicy wrapped, double medicalPremium) 
        {
            _wrapped = wrapped;
            _medicalPremium = medicalPremium;
        }
    
        protected double BasePremium 
        { 
          get 
          {
            _ProcessorsUsed.Add(GetType().Name);
            return _wrapped.BasePremium + _medicalPremium; 
          }
        }
        protected double FixedDeductibleSurchargePercent { 
          get { return _wrapped.FixedDeductibleSurchargePercent }
        }
    
    }
