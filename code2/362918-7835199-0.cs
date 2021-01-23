    Image image = new Image(); //or however you get this
    image.Opacity = 0.5;
    RenderTargetBitmap bmp = new RenderTargetBitmap(image.Source.Width, image.Source.Height, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(image);
    PngBitmapEncoder png = new PngBitmapEncoder();
    png.Frames.Add(BitmapFrame.Create(bmp));
    using (Stream fs= File.Create("test.png"))
    {
    png.Save(fs);
    }
