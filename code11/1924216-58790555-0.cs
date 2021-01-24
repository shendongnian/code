    public static class Attach
    {
        #region CloseProperty
        public static DependencyProperty WindowCloseProperty = DependencyProperty.RegisterAttached("WindowClose",
            typeof(bool), typeof(Attach),
            new UIPropertyMetadata(false, WindowClosePropertyChangedCallback));
        private static void WindowClosePropertyChangedCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs eventArgs)
        {
            var window = (Window)dependencyObject;
            if (window != null && (bool)eventArgs.NewValue)
                window.Close();
        }
        public static bool GetWindowClose(DependencyObject obj)
            => (bool)obj.GetValue(WindowCloseProperty);
        public static void SetWindowClose(DependencyObject obj, bool value)
        {
            obj.SetValue(WindowCloseProperty, value);
        }
        #endregion
    }
