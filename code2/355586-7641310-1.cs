    public partial class Dialog : Form
    {
        public Form Owner { get; set; }
        public ManualResetEvent ResetEvent { get; set; }
        public Dialog()
        {
            InitializeComponent();
        }
        public void SetWaitLabelText(string text)
        {
            if (label1.InvokeRequired)
            {
                Invoke(new Action<string>(SetWaitLabelText), text);
            }
            else
            {
                label1.Text = text;
            }
        }
        private void Dialog_Load(object sender, EventArgs e)
        {
            // Set the event, thus unblocking the other thread
            ResetEvent.Set();
        }
    }
