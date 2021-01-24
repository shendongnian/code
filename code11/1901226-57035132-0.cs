    class FocusableListBox : ListBox
    {
        #region Dependency Proeprty
        public static readonly DependencyProperty IsFocusedControlProperty = DependencyProperty.Register("IsFocusedControl", typeof(Boolean), typeof(FocusableListBox), new UIPropertyMetadata(false, OnIsFocusedChanged));
        public Boolean IsFocusedControl
        {
            get { return (Boolean)GetValue(IsFocusedControlProperty); }
            set { SetValue(IsFocusedControlProperty, value); }
        }
        public static void OnIsFocusedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ListBox listBox = dependencyObject as ListBox;
            listBox.Focus();
        }
        #endregion Dependency Proeprty
    }
