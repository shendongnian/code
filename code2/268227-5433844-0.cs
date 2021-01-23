    public partial class Form1 : Form
    {
        Timer t = new Timer();
    
        public Form1()
        {
            InitializeComponent();
    
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            // enable timer after the handler attached
            t.Enabled = true;
            // Start the timer.
            t.Start();
        }
        void t_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }
