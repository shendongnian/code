    Bitmpa myImage=new Bitmap("myImage.bmp");    
    BitmapData bmpData1=myImage.LockBits(new Rectangle(0,0,myImage.Width,myImage.Height), 
                     System.Drawing.Imaging.ImageLockMode.ReadWrite, myImage.PixelFormat);
    byte[] myImageData = new byte[bmpData1.Stride * bmpData1.Height];
    System.Runtime.InteropServices.Marshal.Copy(bmpData1.Scan0,myImageData,0
                           ,myImageData.Length);
    myImgage.UnlockBits(bmpData1);
