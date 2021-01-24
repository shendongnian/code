    public class FocusExtensions
    {
        public static readonly DependencyProperty SetHasFocusProperty = DependencyProperty.RegisterAttached(
            "HasFocus",
            typeof(bool),
            typeof(FocusExtensions),
            new FrameworkPropertyMetadata(false)
        );
        public static void SetHasFocus(TextBox element, bool value)
        {
            element.SetValue(SetHasFocusProperty, value);
        }
        public static bool GetHasFocus(TextBox element)
        {
            return (bool)element.GetValue(SetHasFocusProperty);
        }
    }
