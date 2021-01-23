    /// <summary>
    ///
    /// </summary>
    public class SuperTB2 : Control
    {
        static SuperTB2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SuperTB2), new FrameworkPropertyMetadata(typeof(SuperTB2)));
        }
        private static DependencyProperty myNameProperty =
    DependencyProperty.Register("MyName", typeof(string), typeof(SuperTB2), new PropertyMetadata("Unicorns !", NameChanged));
        private static void NameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        public string MyName
        {
            get { return (string)GetValue(myNameProperty); }
            set { SetValue(myNameProperty, value); }
        }
        DependencyProperty isRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(SuperTB2), new PropertyMetadata(false, IsReqChanged));
        private static void IsReqChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        public bool IsRequired
        {
            get { return (bool)GetValue(isRequiredProperty); }
            set { SetValue(isRequiredProperty, value); }
        }
    }
