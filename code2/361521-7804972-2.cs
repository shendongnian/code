    public static class MyAttachedBehavior
    {
        public static readonly DependencyProperty
            ConfirmationValueBindingProperty
                = DependencyProperty.RegisterAttached(
                    "ConfirmationValueBinding",
                    typeof(bool),
                    typeof(MyAttachedBehavior),
                    new PropertyMetadata(
                        false,
                        OnConfirmationValueBindingChanged));
        public static bool GetConfirmationValueBinding
            (DependencyObject depObj)
        {
            return (bool) depObj.GetValue(
                            ConfirmationValueBindingProperty);
        }
        public static void SetConfirmationValueBinding
            (DependencyObject depObj,
            bool value)
        {
            depObj.SetValue(
                ConfirmationValueBindingProperty,
                value);
        }
        private static void OnConfirmationValueBindingChanged
            (DependencyObject depObj,
            DependencyPropertyChangedEventArgs e)
        {
            var comboBox = depObj as ComboBox;
            if (comboBox != null && (bool)e.NewValue)
            {
                comboBox.Tag = false;
                comboBox.SelectionChanged -= ComboBox_SelectionChanged;
                comboBox.SelectionChanged += ComboBox_SelectionChanged;
            }
        }
        private static void ComboBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && !(bool)comboBox.Tag)
            {
                var bndExp
                    = comboBox.GetBindingExpression(
                        Selector.SelectedValueProperty);
                var currentItem
                    = (KeyValuePair<int, int>) comboBox.SelectedItem;
                if (currentItem.Key >= 1 && currentItem.Key <= 4
                    && bndExp != null)
                {
                    var dr
                        = MessageBox.Show(
                            "Want to select a Key of between 1 and 4?",
                            "Please Confirm.",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);
                    if (dr == MessageBoxResult.Yes)
                    {
                        bndExp.UpdateSource();
                    }
                    else
                    {
                        comboBox.Tag = true;
                        bndExp.UpdateTarget();
                        comboBox.Tag = false;
                    }
                }
            }
        }
    }
