     public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
     
        public string UserControlText
        {
            get { return (String)GetValue(UserControlTextProperty); }
            set { SetValue(UserControlTextProperty, value); }
        }
        public Brushes  UserControlFlagColor
        {
            get { return (Brushes)GetValue(UserControlBackgroundBrushProperty); }
            set
            {
                SetValue(UserControlBackgroundBrushProperty, value);
              
            }
        }
        public static readonly DependencyProperty UserControlTextProperty =
        DependencyProperty.Register("UserControlTextProperty", typeof(string), typeof(UserControl1), new PropertyMetadata(0));
        public static readonly DependencyProperty UserControlBackgroundBrushProperty =
            DependencyProperty.Register("UserControlBackgroundBrushProperty", typeof(Brushes), typeof(UserControl1), new PropertyMetadata(Brushes.Gray));
    }
