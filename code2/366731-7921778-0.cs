    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            someMethod();
        }
        Thread thread;
        private void someMethod()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            d.Add("cat", 22);
            d.Add("dog", 14);
            d.Add("llama", 2);
            d.Add("iguana", 6);
            thread = new Thread(new ParameterizedThreadStart(Do));
            thread.Start(d);
        }
        delegate void _DisplayText(string x, int y);
        private void DisplayText(string x, int y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new _DisplayText(DisplayText), x, y);
                return;
            }
            label1.Text = x;
            int someValue = 3 + y;
        }
        public void Do(object dic)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)dic;
            while (true)
            {
                foreach (var item in d)
                {
                    DisplayText(item.Key, item.Value);
                    Thread.Sleep(3000);
                }
            }
        }
    }
