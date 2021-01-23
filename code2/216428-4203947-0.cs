    private void Save_Click(object sender, EventArgs e)
    {
    	//Show a save dialog to allow the user to specify where to save the image file
    	using (SaveFileDialog dlgSave = new SaveFileDialog())
    	{
    		dlgSave.Title = "Save Image";
    		dlgSave.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";
    		if (dlgSave.ShowDialog(this) == DialogResult.OK)
    		{
    			//If user clicked OK, then save the image into the specified file
    			using (Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
    			{
    				picturebox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
    				bmp.Save(dlgSave.FileName);
    			}
    		}
    	}
    }
