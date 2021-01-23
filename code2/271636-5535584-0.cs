        private static Bitmap bmpScreenshot;
        bool start = false;
        private static Graphics gfxScreenshot;
        
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {                   
            button1.Enabled = false;
            button2.Enabled = true;
            start = true;
            fillpic();
            backgroundWorker1.RunWorkerAsync();
        }
        public void fillpic()
        {
            bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            pictureBox1.Image = bmpScreenshot;
         }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
            button1.Enabled = true;
            button2.Enabled = false;
            start = false;
        }
        
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
      
               
        
        public void caal()
        {
            TcpClient TCPC = new TcpClient();
            TCPC.Connect("127.0.0.1", 5002);
            if (TCPC.Connected)
            {
                NetworkStream ns = TCPC.GetStream();
                while (ns.CanWrite)
                {
                    fillpic();
                    byte[] data = imageToByteArray(bmpScreenshot);
                    ns.Write(data, 0, data.Length);
                }
            }   
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            caal();
        }
        }
