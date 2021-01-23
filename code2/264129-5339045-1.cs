    System.Drawing.Image originalImage = dpgraphic.image;// replace your image here i.e image bitmap
    //Create empty bitmap image of original size
    float width=0, height=0;
    Bitmap tempBmp = new Bitmap((int)width, (int)height);
    Graphics g = Graphics.FromImage(tempBmp);
    //draw the original image on tempBmp
    g.DrawImage(originalImage, 0, 0, width, height);
    //dispose originalImage and Graphics so the file is now free
    g.Dispose();
    originalImage.Dispose();
    using (MemoryStream ms = new MemoryStream())
    {
        // Convert Image to byte[]
        tempBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //dpgraphic.image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        byte[] imageBytes = ms.ToArray();
    }
