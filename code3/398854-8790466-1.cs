    System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(myBytes);
    System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
    System.Drawing.Image newImage = fullsizeImage .GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
    System.IO.MemoryStream myResult = new System.IO.MemoryStream();
    newImage.Save(myResult ,System.Drawing.Imaging.ImageFormat.Gif);  //Or whatever format you want.
    return  myResult.ToArray();  //Returns a new byte array.
