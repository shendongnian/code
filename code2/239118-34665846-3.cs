    public class CollectionNotEmptyValidationRule : ValidationRule
    {
        public CollectionNotEmptyValidationRule()
            : base(ValidationStep.RawProposedValue, true)
        {
        }
        public string ErrorMessage { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return (value as IEnumerable<object>)?.Any() == true
                ? ValidationResult.ValidResult
                : new ValidationResult(false, ErrorMessage);
        }
    }
    
----------
    <ListView>
        <ListView.ItemsSource>
            <Binding Mode="OneWay"
                        Path="Empty"
                        UpdateSourceTrigger="PropertyChanged">
                <Binding.ValidationRules>
                    <local:CollectionNotEmptyValidationRule ErrorMessage="Collection cannot be empty" />
                </Binding.ValidationRules>
            </Binding>
        </ListView.ItemsSource>
    </ListView>
