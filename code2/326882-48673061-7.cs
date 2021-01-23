    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Web.Helpers;
    using System.Web.Mvc;
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        public PropertyNameValues TargetProp { get; set; }
        public RequiredIfAttribute(string compPropName, string[] compPropValues, string msg) : base(msg)
        {
            this.TargetProp = new PropertyNameValues()
            {
                PropName = compPropName,
                CompValues = compPropValues
            };
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo compareProp = validationContext.ObjectType.GetProperty(TargetProp.PropName);
            var compPropVal = compareProp.GetValue(validationContext.ObjectInstance, null);
            string compPropValAsString = compPropVal?.ToString().ToLower() ?? "";
            var matches = TargetProp.CompValues.Where(v => v == compPropValAsString);
            bool needsValue = matches.Any();
            if (needsValue)
            {
                if (value == null || value.ToString() == "" || value.ToString() == "0")
                {
                    return new ValidationResult(FormatErrorMessage(null));
                }
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // at this point, who cares that we're on this particular instance - find all instances
            PropertyInfo curProp = metadata.ContainerType.GetProperty(metadata.PropertyName);
            RequiredIfAttribute[] allReqIfAttr = curProp.GetCustomAttributes<RequiredIfAttribute>().ToArray();
            // emit validation attributes from all simultaneously, otherwise each will overwrite the last
            PropertyNameValues[] allReqIfInfo = allReqIfAttr.Select(x => x.TargetProp).ToArray();
            string allReqJson = Json.Encode(allReqIfInfo);
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "requiredifany",
                ErrorMessage = ErrorMessageString
            };
            // add name for jQuery parameters for the adapter, must be LOWERCASE!
            modelClientValidationRule.ValidationParameters.Add("props", allReqJson);
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
    public class PropertyNameValues
    {
        public string PropName { get; set; }
        public string[] CompValues { get; set; }
    }
