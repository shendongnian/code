    [Serializable]
    public class CoreObjectBase<T> : IValidatable where T : CoreObjectBase<T>  
    {
        #region IValidatable Members
        public virtual bool IsValid
        {
            get
            {
                // First, check rules that always apply to this type
                var result = new Validator<T>().Validate((T)this);
                // return false if any violations occurred
                return !result.HasViolations;
            }
        }
        public virtual ValidationResponse ValidationResults
        {
            get
            {
                var result = new Validator<T>().Validate((T)this);
                return result;
            }
        }
        public virtual void Validate()
        {
            // First, check rules that always apply to this type
            var result = new Validator<T>().Validate((T)this);
            // throw error if any violations were detected
            if (result.HasViolations)
                throw new RulesException(result.Errors);
        }
        #endregion
    }
