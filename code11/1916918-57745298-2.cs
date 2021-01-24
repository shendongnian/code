    var rect = this.RectangleToScreen(this.ClientRectangle);
    Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
    //this.WindowState = FormWindowState.Minimized;    // If you use the Load event,
                                                       // you don't really need this line.
    using (Graphics g = Graphics.FromImage(bitmap))
    {
        g.CopyFromScreen(rect.Location, Point.Empty, bitmap.Size);
    }
    this.BackgroundImage = bitmap;
    //this.WindowState = FormWindowState.Normal;       // Same here.
