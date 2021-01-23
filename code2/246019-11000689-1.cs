     [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RangeYearToCurrent : RangeAttribute,IClientValidatable { 
        public RangeYearToCurrent(int from) : base(from, DateTime.Today.Year) { }
        #region IClientValidatable Members
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rules = new ModelClientValidationRangeRule(this.ErrorMessage, this.Minimum, this.Maximum);
            yield return rules;
        }
        #endregion
    }
