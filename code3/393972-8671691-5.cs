        public class DataGridRowValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = (BindingGroup)value;
            if (bindingGroup.Items.Count > 0)
            {
                System.Data.DataRowView dataRowView = bindingGroup.Items[0] as System.Data.DataRowView;
                if (dataRowView.Row.HasErrors)
                {
                    string errorMessage = string.IsNullOrWhiteSpace(dataRowView.Row.RowError) ? "There is an unspecified error in the row" : dataRowView.Row.RowError;
                    return new ValidationResult(false, errorMessage);
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
