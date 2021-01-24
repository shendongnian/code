    public partial class Form1 : Form
    {
        private readonly Timer _timer = new Timer();
        private readonly string[] _messages =
            { "hello", "world", "", "folks", "we", "made", "it", "" };
        private int _index;
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 500; // Milliseconds
            _timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = _messages[_index];
            _index = (_index + 1) % _messages.Length;
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
            label1.Text = "stopped";
            _index = 0;
        }
    }
