        public static class IsSelectedBehavior
        {
            public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached(
                "IsSelected", typeof (bool), typeof (IsSelectedBehavior), new UIPropertyMetadata(false, OnIsSelected));
    
            public static bool GetIsSelected(DependencyObject d)
            {
                return (bool) d.GetValue(IsSelectedProperty);
            }
    
            public static void SetIsSelected(DependencyObject d, bool value)
            {
                d.SetValue(IsSelectedProperty, value);
            }
    
            public static void OnIsSelected(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                //Get current ComboBoxItem
                ComboBoxItem test = d as ComboBoxItem;
                //Get the current Param from the ComboBoxItem.Content
                Param p = test.Content as Param;
                //Set the Param.IsSelected property
                p.IsSelected = (bool) e.NewValue;
            }
        }
