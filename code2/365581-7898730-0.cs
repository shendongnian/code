        Image Original;
        Image Overlay;
        Original = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb); //Load your real image here.
        Overlay = new Bitmap(2, 2 ,System.Drawing.Imaging.PixelFormat.Format32bppArgb);//Load your 2x2 (or whatever size you want) overlay image here.
        Graphics gr = Graphics.FromImage(Original);
        for (int y = 0; y < Original.Height; y = y + Overlay.Height)
        {
            for (int x = 0; x < Original.Height; x = x + Overlay.Width)
            {
                gr.DrawImage(Overlay, x, y);
            }  
        }
        gr.Dispose();
