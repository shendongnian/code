        var bmp = Bitmap.FromFile("orig.jpg");
        var newImage = new Bitmap(bmp.Width, bmp.Height + 50);
        var gr = Graphics.FromImage(newImage);
        gr.DrawImageUnscaled(bmp, 0, 0);
        gr.DrawString("this is the added text", SystemFonts.DefaultFont, Brushes.Black ,
            new RectangleF(0, bmp.Height, bmp.Width, 50));
        newImage.Save("newImg.jpg");
