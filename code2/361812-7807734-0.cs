    WriteableBitmap bitmap = new WriteableBitmap(width, height);
    //write bitmap pixels
    Image image = new Image(){Stretch = Stretch.None};
    image.Source = bitmap;
    image.Width = bitmap.PixelWidth;
    image.Height = bitmap.PixelHeight;
    //Print
    PrintDocument printDocument = new PrintDocument();
    printDocument.PrintPage += (sender, args) =>
    {
        //**Add this**
        args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
    
        args.PageVisual = image;
    };
    printDocument.Print("QrCode");
