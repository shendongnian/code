    string myImage = Properties.Settings.Default.LastImage;
    if (File.Exists(myImage))
    {
      pictureBox1.Image = Image.FromFile(myImage);
      //etc...
    }
