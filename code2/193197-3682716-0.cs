    private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
        int width, height;
        width   = webBrowser1.ClientRectangle.Width;
        height  = webBrowser1.ClientRectangle.Height;
        using (Bitmap image = new Bitmap(width, height)) {
            using (Graphics graphics = Graphics.FromImage(image)) {
                Point p, upperLeftSource, upperLeftDestination;
                p                       = new Point(0, 0);
                upperLeftSource         = webBrowser1.PointToScreen(p);
                upperLeftDestination    = new Point(0, 0);
                Size blockRegionSize = webBrowser1.ClientRectangle.Size;
                graphics.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
            }
            image.Save("C:\\Test.bmp");
        }
    }
