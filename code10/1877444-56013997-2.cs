    Bitmap bitmap = null;
    //---------------------------------------------
    string imagePath = @"[Path of the Image]";
    bitmap?.Dispose();
    pictureBox1.Image?.Dispose();
    using (Bitmap tempImage = new Bitmap(imagePath, true))
    {
        bitmap = new Bitmap(tempImage);
        pictureBox1.Image = bitmap;
    }
    File.Delete(imagePath);
