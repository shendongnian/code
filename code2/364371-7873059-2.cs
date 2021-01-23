    public static class CloseBehavior
    {
        public static readonly DependencyProperty IsCloseButtonProperty
            = DependencyProperty.RegisterAttached(
                "IsCloseButton",
                typeof (bool),
                typeof (CloseBehavior),
                new PropertyMetadata(
                   false,
                   OnIsCloseButtonPropertyChanged));
        private static void OnIsCloseButtonPropertyChanged
            (DependencyObject depObj,
             DependencyPropertyChangedEventArgs e)
        {
            var buttonBase = depObj as ButtonBase;
            if (buttonBase != null && (bool)e.NewValue)
            {
                buttonBase.Click
                    += (o, args) =>
                        {
                            var window
                                = GetVisualLogicalParent(
                                      buttonBase,
                                      typeof(Window)) as Window;
                            if (window != null)
                            {
                                window.Close();
                            }
                        };
            }
        }
        public static bool GetIsCloseButton(DependencyObject depObj)
        {
            return (bool)depObj.GetValue(IsCloseButtonProperty);
        }
        public static void SetIsCloseButton(
            DependencyObject depObj,
            bool value)
        {
            depObj.SetValue(IsCloseButtonProperty, value);
        }
        public static DependencyObject GetVisualLogicalParent(
           DependencyObject depObj,
           Type type)
        {
            if (depObj != null)
            {
                var parent = VisualTreeHelper.GetParent(depObj);
                if (parent == null)
                {
                    parent = LogicalTreeHelper.GetParent(depObj);
                }
                if (parent != null)
                {
                    if (type.IsInstanceOfType(parent))
                    {
                        return parent;
                    }
                    else
                    {
                        return GetVisualLogicalParent(parent, type);
                    }
                }
            }
            return null;
        }
    }
