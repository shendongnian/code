    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestControl : ContentView
    {
        public static readonly BindableProperty TestTextProperty = BindableProperty.Create(nameof(TestText), typeof(string), typeof(TestControl));
        public string TestText
        {
            get { return (string)GetValue(TestTextProperty); }
            set { SetValue(TestTextProperty, value); }
        }
        public TestControl()
        {
            InitializeComponent();
            //BindingContext = this;
        }
        
    }
