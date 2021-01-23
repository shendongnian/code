    public class FocusBehavior
    {
        public static readonly DependencyProperty IsFocusedProperty = 
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool?),typeof(FocusBehavior),
            new UIPropertyMetadata(false, new PropertyChangedCallback(OnFocusChanged)));
        public static bool? GetIsFocused(DependencyObject obj)
        {
            return (bool?)obj.GetValue(IsFocusedProperty);
        }
        public static void SetIsFocused(DependencyObject obj, bool? value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }
        private static void OnFocusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement == null) return;
            if (args.OldValue == null) return;
            if (args.NewValue == null) return;
            if ((bool)args.NewValue)
            {
                frameworkElement.Loaded += OnFrameworkElementLoaded;
            }
        }
        private static void OnFrameworkElementLoaded(object sender, RoutedEventArgs args)
        {
            var frameworkElement = sender as FrameworkElement;
            frameworkElement.Focus();
            frameworkElement.Loaded -= OnFrameworkElementLoaded;
            var textControl = frameworkElement as JHATextEditor;
            if (textControl == null) return;
            textControl.SelectAll();
        }
    }
