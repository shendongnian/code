    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        if (pictureBox.Image != null)
        {
            using {var dialog = new SaveFileDialog())
            {
                dialog.Title = ...
                saveFileDialog1.Filter = "Png Image|*.png";
                ...other properties...
                
                if (dialog.ShowDialog == DialogResult.OK)
                {
                     pictureBox.Image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png)
                }
            }
        }
    }
