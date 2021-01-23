    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace ConditionalValidation.Validation
    {
        public class RequiredIfValidator : DataAnnotationsModelValidator<RequiredIfAttribute>
        {
            public RequiredIfValidator(ModelMetadata metadata, ControllerContext context, RequiredIfAttribute attribute)
                : base(metadata, context, attribute)
            {
            }
    
            public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
            {
                // no client validation - I might well blog about this soon!
                return base.GetClientValidationRules();
            }
    
            public override IEnumerable<ModelValidationResult> Validate(object container)
            {
                // get a reference to the property this validation depends upon
                var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);
    
                if (field != null)
                {
                    // get the value of the dependent property
                    var value = field.GetValue(container, null);
    
                    // compare the value against the target value
                    if ((value == null && Attribute.TargetValue == null) ||
                        (value.Equals(Attribute.TargetValue)))
                    {
                        // match => means we should try validating this field
                        if (!Attribute.IsValid(Metadata.Model))
                            // validation failed - return an error
                            yield return new ModelValidationResult { Message = ErrorMessage };
                    }
                }
            }
        }
    }
