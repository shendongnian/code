    public class MinValidationRule : ValidationRule
    {
        public static readonly DependencyProperty AssertMinProperty = DependencyProperty.RegisterAttached(
            "AssertMin",
            typeof(int),
            typeof(MinValidationRule),
            new PropertyMetadata(default(int)));
        public MinValidationRule()
            : base(ValidationStep.ConvertedProposedValue, true)
        {
        }
        public string ErrorMessage { get; set; }
        public int Min { get; set; }
        public static void SetAssertMin(DependencyObject element, int value)
        {
            element.SetValue(AssertMinProperty, value);
        }
        public static int GetAssertMin(DependencyObject element)
        {
            return (int)element.GetValue(AssertMinProperty);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return ((int)value) >= Min
                ? ValidationResult.ValidResult
                : new ValidationResult(false, ErrorMessage);
        }
    }
----------
    <ListView MinHeight="20" ItemsSource="{Binding VmItems}">
        <local:MinValidationRule.AssertMin>
            <Binding Path="VmItems.Count">
                <Binding.ValidationRules>
                    <local:MinValidationRule ErrorMessage="Collection must have at least one item" Min="1" />
                </Binding.ValidationRules>
            </Binding>
        </local:MinValidationRule.AssertMin>
    </ListView>
