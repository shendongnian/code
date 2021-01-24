    [AttributeUsage(AttributeTargets.Class)]
    public class RequierdCompanyNameAttribute: RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validate if top level model
            if (validationContext.ObjectType == typeof(Company))
                return base.IsValid(value, validationContext);
            //no validation inside Employee
            return ValidationResult.Success;
        }
        public override bool IsValid(object value)
        {
            Company company = (Company)value;
            //validate CompanyName with RequiredAttribute
            return base.IsValid(company.CompanyName);
        }
    }
