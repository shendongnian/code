    Bitmap b = new Bitmap(200, 100);
    using (Graphics g = Graphics.FromImage(b)) {
    	g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias;
    	g.DrawString("Hello World!", new Font("Tahoma", 12), Brushes.DarkBlue, 0, 0);
    	b.Save("c:\\MyPic.bmp");
    }
