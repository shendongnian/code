    public static class DisableButtonChromeBehavior 
    {
        public static readonly DependencyProperty DisableButtonChromeProperty = 
            DependencyProperty.RegisterAttached 
            (
                "DisableButtonChrome", 
                typeof(bool),
                typeof(DisableButtonChromeBehavior),
                new UIPropertyMetadata(false, OnDisableButtonChromePropertyChanged) 
            );
        public static bool GetDisableButtonChrome(DependencyObject obj) 
        {
            return (bool)obj.GetValue(DisableButtonChromeProperty); 
        }
        public static void SetDisableButtonChrome(DependencyObject obj, bool value) 
        {
            obj.SetValue(DisableButtonChromeProperty, value); 
        }
        private static void OnDisableButtonChromePropertyChanged(DependencyObject dpo, 
                                                                 DependencyPropertyChangedEventArgs e) 
        {
            Button button = dpo as Button;
            if (button != null) 
            { 
                if ((bool)e.NewValue == true) 
                {
                    button.Loaded += OnButtonLoaded; 
                } 
                else 
                {
                    button.Loaded -= OnButtonLoaded; 
                } 
            } 
        }
        private static void OnButtonLoaded(object sender, RoutedEventArgs e) 
        {
            Button button = sender as Button; 
            Action action = () =>
                {
                    object buttonChrome = VisualTreeHelper.GetChild(button, 0);
                    Type type = buttonChrome.GetType();
                    PropertyInfo propertyInfo = type.GetProperty("RenderMouseOver");
                    propertyInfo.SetValue(buttonChrome, false, null);
                    propertyInfo = type.GetProperty("RenderPressed");
                    propertyInfo.SetValue(buttonChrome, false, null);
                    propertyInfo = type.GetProperty("RenderDefaulted");
                    propertyInfo.SetValue(buttonChrome, false, null); 
                };
            button.Dispatcher.BeginInvoke(action, DispatcherPriority.ContextIdle); 
        } 
    }
