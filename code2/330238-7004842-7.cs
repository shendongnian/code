    private void clicked(object sender, EventArgs e)
    {
        PictureBox pictureBox = sender as PictureBox;//when user clicks on picture box it will be the sender parameter.
        
        if (pictureBox != null)
        {
            //we add number to each of picture boxes at there tags. "picBx[z].Tag = z2"
            int tes = Convert.ToInt32(pictureBox.Tag);
            pnl[tes].BackColor = Color.Red;
        }
    }
