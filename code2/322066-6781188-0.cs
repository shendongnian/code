    public class BaseSurchargePolicy {
    
        public abstract double BasePremium { get; }
        public abstract double FixedDeductibleSurchargePercent { get; }
        public double FixedDeductibleSurchageAmount{
          get
          {
            return (BasePremium * FixedDeductibleSurchargePercent);
          }
        }
    }
    
    public class OldSurchargePolicy : BaseSurchargePolicy 
    {
    
        public double BasePremium { return CollisionPremium + TheftPremium; }
        public double FixedDeductibleSurchargePercent { get; set; }
    
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
    
        public double BasePremium { return _wrapped.BasePremium + _medicalPremium; }
        public double FixedDeductibleSurchargePercent { 
          get { return _wrapped.FixedDeductibleSurchargePercent }
        }
    
    }
