    string image1 = @"c:\image.jpg";
    string image2 = @"c:\image2.jpg";
    
    System.Drawing.Image canvas = Bitmap.FromFile( image1 );
    Graphics gra = Graphics.FromImage( canvas );
    Bitmap smallImg = new Bitmap(image2);
    gra.DrawImage( smallImg, new Point( 70, 70 ) );
    canvas.Save( @"c:\newimage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg );
