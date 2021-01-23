        private int x = 240; // the position of the X axis
        private int y = 0; // the position of the Y axis
        public Bitmap bmp;
        public Graphics g;
        PictureBox display = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            bmp = new Bitmap(360, 390);
            g = Graphics.FromImage(bmp);
            g.DrawLine(new Pen(Color.Red, 2), 5, 5, 5, 250);
            g.DrawLine(new Pen(Color.Red, 2), 5, 250, 300, 250);
            display = new PictureBox(); 
            display.Width = ClientRectangle.Width;
            display.Height = ClientRectangle.Height;
            this.Controls.Add(display);
        }
