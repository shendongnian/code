     public partial class MyCustomControl : UserControl
    {
        public MyCustomControl()
        {
            InitializeComponent();
        }
        public string MyCLRProperty { get; set; }
        public string MyProperty
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(MyCustomControl ));
    }
