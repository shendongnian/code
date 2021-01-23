    public class KeyboardFocus
    {
        public static bool GetReturnFocusAfterEnable(DependencyObject obj)
        {
            return (bool)obj.GetValue(ReturnFocusAfterEnableProperty);
        }
        public static void SetReturnFocusAfterEnable(DependencyObject obj, bool value)
        {
            obj.SetValue(ReturnFocusAfterEnableProperty, value);
        }
        private static Dictionary<object, IInputElement> values = new Dictionary<object, IInputElement>();
        // Using a DependencyProperty as the backing store for ReturnFocusAfterEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReturnFocusAfterEnableProperty =
            DependencyProperty.RegisterAttached("ReturnFocusAfterEnable", typeof(bool), typeof(KeyboardFocus), new UIPropertyMetadata(false, PropertyChangedCallback));
        static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                UIElement element = d as UIElement;
                if (element != null)
                {
                    element.IsEnabledChanged += (element_IsEnabledChanged);
                }
            }
            else
            {
                UIElement element = d as UIElement;
                if (element != null)
                {
                    element.IsEnabledChanged -= (element_IsEnabledChanged);
                }
            }
        }
        static void element_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                if (values.ContainsKey(sender))
                {
                    Keyboard.Focus(values[sender]);
                    values.Remove(sender);
                }
            }
            else
            {
                values[sender] = Keyboard.FocusedElement;
            }            
        }
    }
