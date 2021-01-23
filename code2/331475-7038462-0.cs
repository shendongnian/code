     System.IO.MemoryStream defaultImageStream = new System.IO.MemoryStream();
     Bitmap NewImage =new Bitmap(votingImage,new Size(720,227));
     Image b = (Image)NewImage;
     b.Save(defaultImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
     defaultImageData = new byte[defaultImageStream.Length];
     //assign byte array the content of image
     defaultImageData = defaultImageStream .ToArray();
