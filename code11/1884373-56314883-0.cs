    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        private void MyUserControl_Load(object sender, EventArgs e)
        {
        }
        public string KandidaatNummer
        {
            get
            {
                return labelNummer.Text;
            }
            set
            {
                labelNummer.Text = value;
            }
        }
    }
