    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, 
        AllowMultiple = false, Inherited = true)]
    public class MyCustomClientValidationAttribute : ValidationAttribute, 
        IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return true;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "mycustomvalidator",
            };
            var viewContext = (ViewContext)context;
            var dependentProperty1 = viewContext.ViewData.TemplateInfo
                .GetFullHtmlFieldId("DependentProperty1");
            //var prefix = viewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
            rule.ValidationParameters.Add("dependentproperty1", dependentProperty1);
            yield return rule;
        }
    }
