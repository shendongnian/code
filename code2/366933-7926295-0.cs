    private void sizeAbleCTR2_LocationChanged(object sender, EventArgs e)
    {
        int srcHeightDiff = panel2.Height - sizeAbleCTR2.Height;
        int dstHeightDiff = panel1.Height - sizeAbleCTR1.Height;
    
        int locY = dstHeightDiff * (sizeAbleCTR2.Location.Y / srcHeightDiff);
    
        int srcWidthDiff = panel2.Width - sizeAbleCTR2.Width;
        int dstWidthDiff = panel1.Width - sizeAbleCTR1.Width;
    
        int locX = dstWidthDiff * (sizeAbleCTR2.Location.X / srcWidthDiff);
    
        sizeAbleCTR1.Location = new Point(locX, locY);
    }
