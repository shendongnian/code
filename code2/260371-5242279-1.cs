    // Remove the PicturBox control if it exists.
    private void deleteButton_Click(object sender, System.EventArgs e)
    {
       if(panel1.Controls.Contains(pictureBox))
       {
          panel1.Controls.Remove(pictureBox);
       }
    }
