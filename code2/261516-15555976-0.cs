    var image = Image.FromFile(fileName);
    var ratioX = (double)maxWidth / image.Width;
    var ratioY = (double)maxHeight / image.Height;
    var ratio = Math.Min(ratioX, ratioY);
    var newWidth = (int)(image.Width * ratio);
    var newHeight = (int)(image.Height * ratio);
    var newImage = new Bitmap(newWidth, newHeight);
    Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
    newImage.Save(cachedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
