    public class QualificationSetValidator : PropertyValidator {
        // Default error message specified in the base ctor
        // but it can be overriden using WithMessage in the RuleFor call
        public QualificationSetValidator() : base("At least one property must be selected.") {
			
        }
        protected override bool IsValid(PropertyValidatorContext context) {
            // You can retrieve a reference to the object being validated 
            // through the context.Instance property
            tblNeutralFileMaint neutral = (tblNeutralFileMaint)context.Instance;
                      
            // You can also retrieve a reference to the property being validated
            // ...using context.PropertyValue
            // here is where you can do the custom validation
            // and return true/false depending on success.
		
         }
     }
