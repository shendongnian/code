    public partial class Test : Form
    {
       private int _iteration = 0;
        private Stopwatch _sw;
        private int _pressedKey;
        public Test()
        {
            InitializeComponent();
        }
        private void Test_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == _pressedKey) return;
            _iteration++;
            _sw = new Stopwatch();
            _sw.Start();
            _pressedKey = e.KeyValue;
        }
        private void Test_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKey = -1;
            label1.Text = $"Iteration:{_iteration}. Elapsed: {_sw.ElapsedMilliseconds}ms";
        }
    }
