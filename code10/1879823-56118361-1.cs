    Original_px OrPix = null;
    
    private void showFullPictureToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(OrPix == null)
        {
           OrPix = new Original_px();
           OrPix.FormClosed += PixClosed;
        }
        OrPix.Show();
    }
    private void PixClosed(object sender, FormClosedEventArgs e)
    {
        OrPix = null;
    }
