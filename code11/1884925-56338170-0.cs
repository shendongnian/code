        public string MyRtf { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MyRtf = richTextBox1.Rtf;
        }
