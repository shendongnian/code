public PictureBox GetPictureBox(string pictureBoxName)
{
    if(this.Controls.ContainsKey(pictureBoxName))
    {
        Control control = this.Controls[pictureBoxName];
        PictureBox pictureBox;
        if ((pictureBox = control as PictureBox) != null)
        {
            return pictureBox;
        }
    }
    return null;
}
