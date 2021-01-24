    public class MyControl : Grid
    {
        public static bool GetDisabled(DependencyObject obj) => (bool)obj.GetValue(DisabledProperty);
        public static void SetDisabled(DependencyObject obj, bool value) => obj.SetValue(DisabledProperty, value);
        public static readonly DependencyProperty DisabledProperty =
            DependencyProperty.RegisterAttached("Disabled", typeof(bool), typeof(MyControl),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits,
            (d, e) =>
            {
                if (d is MyControl control)
                    control.IsEnabled = !(bool)e.NewValue;
            }));
    }
