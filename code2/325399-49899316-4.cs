     internal class EllipsisStringBehavior
    {
        public static readonly DependencyProperty CharacterLimitDependencyProperty = DependencyProperty.RegisterAttached("CharacterLimit", typeof(int), typeof(EllipsisStringBehavior), new PropertyMetadata(255, null, OnCoerceCharacterLimit));
        public static readonly DependencyProperty InputTextDependencyProperty = DependencyProperty.RegisterAttached("InputText", typeof(string), typeof(EllipsisStringBehavior), new PropertyMetadata(string.Empty, OnInputTextChanged));
        // Input Text
        public static string GetInputText(DependencyObject dependencyObject)
        {
            return Convert.ToString(dependencyObject.GetValue(InputTextDependencyProperty));
        }
        public static void SetInputText(DependencyObject dependencyObject, string inputText)
        {
            dependencyObject.SetValue(InputTextDependencyProperty, inputText);
        }
        // Character Limit
        public static int GetCharacterLimit(DependencyObject dependencyObject)
        {
            return Convert.ToInt32(dependencyObject.GetValue(CharacterLimitDependencyProperty));
        }
        public static void SetCharacterLimit(DependencyObject dependencyObject, object characterLimit)
        {
            dependencyObject.SetValue(CharacterLimitDependencyProperty, characterLimit);
        }
        private static void OnInputTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock textblock = (TextBlock)d;
           
            string input = e.NewValue == null ? string.Empty : e.NewValue.ToString();
            int limit = GetCharacterLimit(d);
            string result = input;
            if (input.Length > limit && input.Length != 0)
            {
                result = $"{input.Substring(0, limit)}...";
            }
            textblock.Text = result;
        }
        private static object OnCoerceCharacterLimit(DependencyObject d, object baseValue)
        {
            return baseValue;
        }
    }
