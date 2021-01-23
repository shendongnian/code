    public void RotateAndSaveImage(BitmapImage sourceImage, double angle, string filePath)
    {
        TransformGroup transformGroup = new TransformGroup();
        RotateTransform rotateTransform = new RotateTransform(angle);
        rotateTransform.CenterX = sourceImage.PixelWidth / 2.0;
        rotateTransform.CenterY = sourceImage.PixelHeight / 2.0;
        transformGroup.Children.Add(rotateTransform);
        wpfImage.RenderTransform = transformGroup;
        DrawingVisual vis = new DrawingVisual();
        DrawingContext cont = vis.RenderOpen();
        cont.PushTransform(transformGroup);
        cont.DrawImage(sourceImage, new Rect(new Size(sourceImage.PixelWidth, sourceImage.PixelHeight)));
        cont.Close();
        RenderTargetBitmap rtb = new RenderTargetBitmap((int)sourceImage.PixelWidth, (int)sourceImage.PixelHeight, 96d, 96d, PixelFormats.Default);
        rtb.Render(vis);
        FileStream stream = new FileStream(filePath, FileMode.Create);
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(rtb));
        encoder.Save(stream);
        stream.Close();
    }
