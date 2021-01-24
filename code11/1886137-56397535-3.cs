    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            userControlB1.BroadcastName += UserControlB1_BroadcastName;
        }
        private void UserControlB1_BroadcastName(UserControlB source, string name)
        {
            // ... do something to Form1 with the received information in here ...
        }
    }
