    public static class EditingStateBehavior
    {
        #region IsEditing
        public static bool GetIsEditing(DependencyObject obj) => (bool)obj.GetValue(IsEditingProperty);
        public static void SetIsEditing(DependencyObject obj, bool value) => obj.SetValue(IsEditingProperty, value);
        public static readonly DependencyProperty IsEditingProperty =
           DependencyProperty.Register(
           "IsEditing",
           typeof(bool),
           typeof(EditingStateBehavior));
        #endregion IsEditing
        #region Enabling
        public static bool GetIsEditingEnabled(DependencyObject obj) => (bool)obj.GetValue(IsEditingEnabledProperty);
        public static void SetIsEditingEnabled(DependencyObject obj, bool value) => obj.SetValue(IsEditingEnabledProperty, value);
        public static readonly DependencyProperty IsEditingEnabledProperty =
            DependencyProperty.Register(
            "IsEditingEnabled",
            typeof(bool),
            typeof(TextBox),
            new PropertyMetadata(OnIsEditingEnabledChanged));
        private static void OnIsEditingEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox is null) return;
            textBox.GotFocus += (x, p) => UpdateStatus(x as FrameworkElement, true);
            textBox.LostFocus += (x, p) => UpdateStatus(x as FrameworkElement, false);
            //Also, you cam implement something to handle if you don't want to receive notifications anymore....
        }
        private static void UpdateStatus(FrameworkElement frameworkElement, bool value) => frameworkElement.SetValue(IsEditingProperty, value);
        #endregion Enabling
    }
