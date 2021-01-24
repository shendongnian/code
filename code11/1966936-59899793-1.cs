    public sealed partial class CustomControl : UserControl
    {
        public string DisplayName
        {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register(nameof(DisplayName), typeof(string), typeof(CustomControl), 
                new PropertyMetadata("DisplayText", new PropertyChangedCallback(OnChanged)));
        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomControl customControl = (CustomControl)d;
            d.DisplayText = e.NewValue as string;
        }
        public CustomControl()
        {
            this.InitializeComponent();
        }
    }
