    public partial class Test : Form
    {
        private int _iteration = 1;
        private Stopwatch _sw;
    
        public Test()
        {
            InitializeComponent();
        }
    
        private void Test_KeyDown(object sender, KeyEventArgs e)
        {
            _sw = new Stopwatch();
            _sw.Start();
        }
    
        private void Test_KeyUp(object sender, KeyEventArgs e)
        {
            label1.Text = $"Iteration:{_iteration++}. Elapsed: {_sw.ElapsedMilliseconds}ms";
        }
    }
