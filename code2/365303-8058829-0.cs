    public static class TextBoxUpperCaseBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled",
                                                typeof(bool),
                                                typeof(TextBoxUpperCaseBehavior),
                                                new UIPropertyMetadata(false, OnIsEnabledChanged));
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsEnabled(TextBox comboBox)
        {
            return (bool)comboBox.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(TextBox comboBox, bool value)
        {
            comboBox.SetValue(IsEnabledProperty, value);
        }
        private static void OnIsEnabledChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = target as TextBox;
            if ((bool)e.NewValue == true)
            {
                textBox.CharacterCasing = CharacterCasing.Upper;
                textBox.TextChanged += textBox_TextChanged;
            }
            else
            {
                textBox.CharacterCasing = CharacterCasing.Normal;
                textBox.TextChanged -= textBox_TextChanged;
            }
        }
        private static void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.ToUpper() != textBox.Text)
            {
                textBox.Text = textBox.Text.ToUpper();
            }
        }
    }
