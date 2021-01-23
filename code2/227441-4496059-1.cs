    public partial class TextBoxReadOnlyLooksDisabled : UserControl
    {
        public TextBoxReadOnlyLooksDisabled()
        {
            InitializeComponent();
            DataContext = this;
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string),
                                                                                             typeof(TextBoxReadOnlyLooksDisabled));
       
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
