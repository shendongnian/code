        public static string GetValueAsString(this ModelBindingContext context, string formValueName, bool treatWhitespaceAsNull = true) {
            var providerResult = context.ValueProvider.GetValue(formValueName);
            if (providerResult.IsNotNull() && !providerResult.AttemptedValue.IsNull()) {
                if (treatWhitespaceAsNull && providerResult.AttemptedValue.IsNullOrWhiteSpace()) {
                    return null;
                } else {
                    return providerResult.AttemptedValue.Trim();
                }
            }
            return null;
        }
