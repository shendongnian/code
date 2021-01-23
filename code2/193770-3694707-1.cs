    public abstract class BusinessRules : IBusinessRules {
        protected BusinessRules() { 
        }
        protected virtual bool CanCalculateCore() {
             return false; // Cannot calculate by default
        }
        protected virtual string CalculateCore() { 
             throw new NotImplementedException("Cannot calculate"); 
        }
        protected abstract string PerformCore();
        #region IBusinessRules Members
        public string Perform()
        {
            return PerformCore();
        }
        public bool CanCalculate
        {
            get { return CanCalculateCore(); }
        }
        public string Calculate()
        {
            return CalculateCore();
        }
        #endregion
    }
