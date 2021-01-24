    public partial class UserControlB : UserControl
    {
        public delegate void dlgBroadcastName(UserControlB source, string name);
        public event dlgBroadcastName BroadcastName;
        public UserControlB()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (BroadcastName != null)
            {
                BroadcastName(this, textBox1.Text);
            }
        }
    }
