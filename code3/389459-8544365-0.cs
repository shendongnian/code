    List<Control> MyList = new List<Control>();
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in MyList)
        {
            // Try to cast the Control object to a PictureBox
            PictureBox picBox = ctrl as PictureBox;
            if (picBox != null)
            {
                picBox.Image = WindowsFormsApplication1.Properties.Resources.image;
            }
        }
    }
