        private void ButtonGetImage_Click(object sender, EventArgs e)
        {
          if (SourcePictureBox.Image != null)//Just to make sure it's not empty.
           {
             Bitmap graphic = new Bitmap(SourcePictureBox.Image);
              {
                //Add some logic to modify Image if you want.
                graphic.Save(@"F:\Image.bmp");//An appropriate path to save the file.
                graphic.Dispose();
              }
           }
        }
