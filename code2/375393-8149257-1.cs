    public partial class Form1 : Form
    {
        Timer timer = null;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 3 * 60 * 60 * 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // Do what you need
            File.AppendAllText(log_file, your_message);
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Tick -= timer_Tick;
        }
    }
