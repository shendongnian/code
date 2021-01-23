    private void sizeAbleCTR2_LocationChanged(object sender, EventArgs e)
    {
        float srcHeightDiff = panel2.Height - sizeAbleCTR2.Height;
        float dstHeightDiff = panel1.Height - sizeAbleCTR1.Height;
    
        int locY = (int)(dstHeightDiff * (sizeAbleCTR2.Location.Y / srcHeightDiff));
    
        float srcWidthDiff = panel2.Width - sizeAbleCTR2.Width;
        float dstWidthDiff = panel1.Width - sizeAbleCTR1.Width;
    
        int locX = (float)(dstWidthDiff * (sizeAbleCTR2.Location.X / srcWidthDiff));
    
        sizeAbleCTR1.Location = new Point(locX, locY);
    }
