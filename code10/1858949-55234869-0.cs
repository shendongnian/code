    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty TextCombinedProperty =
            DependencyProperty.Register("TextCombined", typeof(string),
                typeof(UserControl1), new PropertyMetadata(String.Empty));
        public string TextCombined
        {
            get { return (string)GetValue(TextCombinedProperty); }
            set { SetValue(TextCombinedProperty, value); }
        }
        public UserControl1()
        {
            InitializeComponent();
            txtF.TextChanged += OnTextFieldTextChanged;
            txtL.TextChanged += OnTextFieldTextChanged;
        }
        private void OnTextFieldTextChanged(object _, TextChangedEventArgs __)
        {
            SetCurrentValue(TextCombinedProperty, $"{txtF.Text} {txtL.Text}");
        }
    }
