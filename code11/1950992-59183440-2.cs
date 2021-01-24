    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private Control friendControl = null;
        [DefaultValue(null)]
        public Control FriendControl
        {
            get { return friendControl; }
            set
            {
                if (value == null)
                    MessageBox.Show("Why null????");
                else
                    friendControl = value;
            }
        }
    }
