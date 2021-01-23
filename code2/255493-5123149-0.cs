    public partial class MyDialog : Form
    {
        private Timer myTimer;
        public MyDialog()
        {
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Interval = 5000;
            myTimer.Enabled = false;
        }
        private Cursor SaveCursor;
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            myTimer.Enabled = true;
        }
        void myTimer_Tick(object sender, EventArgs e)
        {
            Cursor = SaveCursor;
            myTimer.Enabled = false;
        }
    }
