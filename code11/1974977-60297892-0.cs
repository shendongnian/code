      public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
     
        public string UserControlText
        {
            get { return FlagTitle.Text; }
            set { FlagTitle.Text = value; }
        }
        public Brush UserControlBackgroundBrush
        {
            get { return FlagIcon.Fill;  }
            set { FlagIcon.Fill = value; }
        }
    }
