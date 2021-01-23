    private void clicked(object sender, EventArgs e)
    {
        PictureBox pictureBox = sender as PictureBox;
    
        if (pictureBox != null)
        {
            int number = Convert.ToInt32(pictureBox.Tag);
            ...
        }
    }
