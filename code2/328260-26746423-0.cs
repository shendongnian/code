        public virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "requiredif",
            };
            // Find the value on the control we depend on...
            string depProp = this.GetHtmlId(metadata, context, this.DependentPropertyName);
            rule.ValidationParameters.Add("dependentproperty", depProp);
            yield return rule;
        }
