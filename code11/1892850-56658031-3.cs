    private void PictureBox_Click(object sender, EventArgs e)
    {
        var thisPictureBox = sender as PictureBox;
        // May not be necessary, but it's a good practice to ensure that 'sender' was actually
        // a PictureBox and not some other object by checking if 'thisPictureBox' is 'null'
        if (thisPictureBox == null) return;
            
        if (thisPictureBox.Image == Properties.Resorces.available)
        {
            thisPictureBox.Image = Properties.Resorces.selected;
        {
        else if (thisPictureBox.Image == Properties.Resorces.selected)
        {
            thisPictureBox.Image = Properties.Resorces.available;
        }
    }
