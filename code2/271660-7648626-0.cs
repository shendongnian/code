        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
       
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
             Point pt = new Point();
            GetCursorPos(ref pt);
            textBox1.Text = pt.X.ToString();
            textBox2.Text = pt.Y.ToString();
        }
        
    }
