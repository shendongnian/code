     public static class Attach
    {
        public static DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached("IsFocused", typeof(bool), typeof(Attach), new UIPropertyMetadata(false, OnIsFocusedChanged));
        public static bool GetIsFocused(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsFocusedProperty);
        }
        public static void SetIsFocused(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsFocusedProperty, value);
        }
        public static void OnIsFocusedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var textBox = dependencyObject as TextBox;
            var newValue = (bool)dependencyPropertyChangedEventArgs.NewValue;
            var oldValue = (bool)dependencyPropertyChangedEventArgs.OldValue;
            if (!newValue || oldValue || (textBox?.IsFocused ?? false)) return;
            if (textBox == null) return;
            textBox.Loaded += (sender, e) =>
            {
                textBox.Dispatcher?.BeginInvoke((Action)(() =>
                {
                    textBox.Focus();
                    Keyboard.Focus(textBox);
                }), DispatcherPriority.Render);
            };
        }
    }
