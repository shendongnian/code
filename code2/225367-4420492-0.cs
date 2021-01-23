    private void Form1_Load(object sender, EventArgs e) 
    { 
        Bitmap bmp = new Bitmap(canvas.Image); 
        System.Drawing.Imaging.BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, 800, 600), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb); 
  
        Random rand = new Random(); 
        unsafe 
        { 
        // ....
