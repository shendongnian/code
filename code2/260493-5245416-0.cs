    private void picturebox_Click(object sender, EventArgs e)
    {
        var pictureBox = sender as PictureBox;
        if (pictureBox != null) {
            pictureBox.BackColor = Color.Blue;
        }
    }
