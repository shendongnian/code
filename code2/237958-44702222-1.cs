    public partial class BusyForm : Form
    {
        public BusyForm(string text = "Busy performing action ...")
        {
            InitializeComponent();
            this.Text = text;
            this.ControlBox = false;
        }
        public void Start()
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                this.ShowDialog();
            });
        }
        public void Stop()
        {
            BeginInvoke((Action)delegate { this.Close(); });
        }
        public void ChangeText(string newText)
        {
            BeginInvoke((Action)delegate { this.Text = newText; });
        }
    }
