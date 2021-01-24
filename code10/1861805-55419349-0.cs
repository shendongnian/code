    public class Bind : Binding
    {
        // validation rule
        class Rule : ValidationRule
        {
            public Rule() : base(ValidationStep.RawProposedValue, true) { }
            public override ValidationResult Validate(object value, CultureInfo cultureInfo) => ValidationResult.ValidResult;
            public override ValidationResult Validate(object value, CultureInfo cultureInfo, BindingExpressionBase owner)
            {
                if (!string.IsNullOrEmpty((string)value))
                    return new ValidationResult(false, GetError(owner.Target));
                return base.Validate(value, cultureInfo, owner);
            }
        }
        // attached property to hold error text
        public static string GetError(DependencyObject obj) => (string)obj.GetValue(ErrorProperty);
        public static void SetError(DependencyObject obj, string value) => obj.SetValue(ErrorProperty, value);
        public static readonly DependencyProperty ErrorProperty = DependencyProperty.RegisterAttached("Error", typeof(string), typeof(Bind));
        // custom binding
        public Bind() : base() => Init();
        public Bind(string path) : base(path) => Init();
        void Init()
        {
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ValidationRules.Add(new Rule());
        }
    }
