    public Bitmap CaptureControl(Control c) {
        Bitmap b = new Bitmap(c.Width, c.Height, System.Drawing.Imaging.PixelFormat.Format24BppRgb);
        c.DrawToBitmap(b, b.ClientRectangle);
        return b;
    }
