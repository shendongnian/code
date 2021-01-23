    using (Image image = Image.FromFile("myImage.jpg"))
    using(Graphics g = Graphics.FromImage( image)){
      g.DrawImage( myWaterMarkImage, myPosition);
      image.Save(myFilename);
    }
