    public class ValidationBorder
    {
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.RegisterAttached(
                "HasError",
                typeof(bool?),
                typeof(ValidationBorder),
                new PropertyMetadata(default(bool?))
            );
        public static void SetHasError(UIElement element, bool? value)
        {
            element.SetValue(HasErrorProperty, value);
        }
        public static bool? GetHasError(UIElement element)
        {
            return (bool?)element.GetValue(HasErrorProperty);
        }
    }
