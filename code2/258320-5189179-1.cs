    UserControl control = new UserControl1();
    control.Measure(new Size(300, 300));
    control.Arrange(new Rect(new Size(300,300)));
    RenderTargetBitmap bmp = new RenderTargetBitmap(300, 300, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(control);
    var encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(bmp));
    using (Stream stm = File.Create(@"c:\test.png"))
       encoder.Save(stm);
