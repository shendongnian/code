    [HasSelfValidation]
        public partial class MyObject : IBusinessObject
        {
            private readonly IBusinessObjectValidator validator = new BusinessObject();
    
            private IBusinessObjectValidator BusinessObjectValidator
            {
                get
                {
                    return validator ;
                }
            }
        public Comment()
        {
            AddRule(new ValidateRequired("Title"));
        }
        public void AddRule(BusinessRule rule)
        {
            validator .AddRule(rule);
        }
        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            validator.Validate(this, results);
        }
    }
