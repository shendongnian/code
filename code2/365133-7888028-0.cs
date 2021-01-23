        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            toolTip.InitialDelay = 0;
        }
        private ToolTip toolTip = new ToolTip();
        private bool isShown = false;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(textBox1 == this.GetChildAtPoint(e.Location))
            {
                if(!isShown)
                {
                    toolTip.Show("MyToolTip", this, e.Location);
                    isShown = true;
                }
            }
            else
            {
                toolTip.Hide(textBox1);
                isShown = false;
            }
        }
