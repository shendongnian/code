    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
	public class RequiredIfAttribute : ValidationAttribute, IClientValidatable {
		private const string _defaultErrorMessage = "'{0}' is required when {1} equals {2}.";
		public string DependentProperty { get; set; }
		public object TargetValue { get; set; }
		public RequiredIfAttribute(string dependentProperty, object targetValue):base(_defaultErrorMessage) {
			this.DependentProperty = dependentProperty;
			this.TargetValue = targetValue;
		}
		public override string FormatErrorMessage(string name) {
			return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, DependentProperty, TargetValue);
		}
		protected override ValidationResult IsValid(object value, ValidationContext context) {
			if (context.ObjectInstance != null) {
				Type type = context.ObjectInstance.GetType();
				PropertyInfo info = type.GetProperty(DependentProperty);
				object dependentValue;
				if (info != null) {
					dependentValue = info.GetValue(context.ObjectInstance, null);
					if (object.Equals(dependentValue, TargetValue)) {
						if (string.IsNullOrWhiteSpace(Convert.ToString(value))) {
							return new ValidationResult(ErrorMessage);
						}
					}
				}
			}
			return ValidationResult.Success;
		}
		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {
			ModelClientValidationRule rule = new ModelClientValidationRule();
			rule.ErrorMessage = this.FormatErrorMessage(metadata.PropertyName);
			rule.ValidationType = "requiredif";
			rule.ValidationParameters.Add("depedentproperty", DependentProperty);
			rule.ValidationParameters.Add("targetvalue", TargetValue);
			yield return rule;
		}
	}
