     [TemplatePart(Name = "PART_Input")]
    public class SuperTB2 : Control
    {
        private TextBox PART_Input;
        static SuperTB2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SuperTB2), new FrameworkPropertyMetadata(typeof(SuperTB2)));
        }
        public SuperTB2()
        {
            Loaded += SuperTb2Loaded;
        }
        public override void OnApplyTemplate()
        {
            PART_Input = GetTemplateChild("PART_Input") as TextBox;
            if (PART_Input != null)
            {
                PART_Input.GotFocus += PartInputGotFocus;
                PART_Input.LostFocus += PartInputLostFocus;
            }
        }
        void PartInputLostFocus(object sender, RoutedEventArgs e)
        {
            if (PART_Input.Text == string.Empty)
            {
                PART_Input.Text = Name;
                PART_Input.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        void PartInputGotFocus(object sender, RoutedEventArgs e)
        {
            if (PART_Input.Text.Equals(Name))
            {
                PART_Input.Text = string.Empty;
                PART_Input.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        void SuperTb2Loaded(object sender, RoutedEventArgs e)
        {
            if (PART_Input.Text == string.Empty)
            {
                PART_Input.Text = Name;
                PART_Input.Foreground = new SolidColorBrush(Colors.Gray);
            }
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
        public string DefaultTextValue
        {
            get { return (string)GetValue(DefaultTextValueProperty); }
            set { SetValue(DefaultTextValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for DefaultTextValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultTextValueProperty =
            DependencyProperty.Register("DefaultTextValue", typeof(string), typeof(SuperTB2), new UIPropertyMetadata("100"));
    }
