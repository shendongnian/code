      public Form1()
        {
            InitializeComponent();
            
            this.Click += new EventHandler(MujClickHandler);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                MessageBox.Show(e.KeyCode.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Paint += new PaintEventHandler(MujPaintHandler);
        }
        public void MujPaintHandler(object sender,PaintEventArgs e)   
        {
            Graphics gfx=e.Graphics;  
            gfx.FillRectangle(new SolidBrush(Color.DarkViolet),100,100,200,200);  
            
        }
        public void MujClickHandler(object sender,EventArgs e)      
        { 
            this.Text="aaaaa";
            this.RaisePaintEvent(this, new PaintEventArgs(this.CreateGraphics(), this.RectangleToClient(new Rectangle())));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(MujPaintHandler);
        } 
