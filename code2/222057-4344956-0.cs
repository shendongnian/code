    public delegate void OpenFormDelegate(string txt);
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var button1 = new Button();
            button1.Text = "Run for 5 secs and open new window";
            button1.Dock = DockStyle.Top;
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Run));
            t.Start();
        }
        public void Run()
        {
            Thread.Sleep(5000); // sleep for 5 seconds
            this.BeginInvoke(new OpenFormDelegate(OpenNewForm), "Hello World !");
        }
        public void OpenNewForm(string text)
        {
            Form f = new Form();
            f.Text = text;
            f.Show();
        }
    }
