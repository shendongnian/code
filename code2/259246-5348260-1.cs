    namespace simpleUserControl
    {
    public partial class UserControl1 : UserControl
    {
        public string text
        {
            get { return (string)GetValue(textProperty); }
            set { SetValue(textProperty, value); }
        }
    
        public static readonly DependencyProperty textProperty = DependencyProperty.Register("text", typeof(string), typeof(UserControl1));
    
        public UserControl1()
        {                       
            InitializeComponent();
        }
    }
    }
