    namespace Checked.Entitites
    {
        public class BooleanRequiredAttribute : ValidationAttribute, IClientValidatable
        {
    
            public BooleanRequiredAttribute()
            {        }
    
            public override bool IsValid(object value)
            {
                return value != null && (bool)value == true;
            }
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                //return new ModelClientValidationRule[] { new ModelClientValidationRule() { ValidationType = "booleanrequired", ErrorMessage = this.ErrorMessage } };
                yield return new ModelClientValidationRule() { ValidationType = "booleanrequired", ErrorMessage = this.ErrorMessageString };
            }
        }
    }
