    string[] images = Directory.GetFiles(@"C:\Dir", "*.jpg");
    foreach (string image in images)
    {
      pictureBox1.Image = new Bitmap(image);
      Thread.Sleep(5000);
    }
