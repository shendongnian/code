    public partial class BusyForm : Form
    {
        private Thread _thread { get; set; }
        public BusyForm(string text = "Busy performing action ...")
        {
            InitializeComponent();
            this.Text = text;
            this.ControlBox = false;
            _thread = new Thread(() => this.ShowDialog());
        }
        public void Start()
        {
            _thread.Start();
        }
        public void Stop()
        {
            _thread.Abort();
        }
    }
