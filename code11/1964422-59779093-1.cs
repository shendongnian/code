    public partial class Form1 : Form
    {
        private readonly Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 100; // Milliseconds
            _timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Top = (label1.Top + 10) % 150 + 5;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6) {
                _timer.Start();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _timer.Stop();
        }
    }
