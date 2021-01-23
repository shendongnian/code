    public static class IsValid
    {
        public static readonly DependencyProperty InputProperty = DependencyProperty.RegisterAttached(
            "Input",
            typeof(IsValidInputExtension),
            typeof(IsValid),
            new UIPropertyMetadata(onInput));
        public static IsValidInputExtension GetInput(DependencyObject d)
        {
            return (IsValidInputExtension)d.GetValue(InputProperty);
        }
        public static void SetInput(DependencyObject d, IsValidInputExtension value)
        {
            d.SetValue(InputProperty, value);
        }
        private static void onInput(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)d;
            var value = (IsValidInputExtension)e.NewValue;
            if (value == null)
            {
                textBox.PreviewTextInput -= validateInput;
                textBox.PreviewKeyDown -= validateKeyDown;
                return;
            }
            textBox.PreviewTextInput += validateInput;
            textBox.PreviewKeyDown += validateKeyDown;
        }
        private static void validateInput(object sender, TextCompositionEventArgs e)
        {
            // dispatch validation to specified markup class ...
            var textBox = (TextBox) sender;
            var markup = (IsValidInputExtension)textBox.GetValue(InputProperty);
            markup.ValidateInput(sender, e);
        }
        private static void validateKeyDown(object sender, KeyEventArgs e)
        {
            // dispatch validation to specified markup class ...
            var textBox = (TextBox)sender;
            var markup = (IsValidInputExtension)textBox.GetValue(InputProperty);
            markup.ValidateKeyDown(sender, e);
        }
    }
