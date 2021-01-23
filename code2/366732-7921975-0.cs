        private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        private Dictionary<string, int> d = new Dictionary<string, int>()
        {
            {"cat", 22},
            {"dog", 14},
            {"llama", 2},
            {"iguana", 6}
        };
        public Form1()
        {
            InitializeComponent();
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (var item in d)
            {
                label1.Text = item.Key;
                int someValue = 3 + item.Value;
            }
            t.Start();
        }
