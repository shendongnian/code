    // Create a render target to render your visual onto. The '96' values are the dpi's, you can set this as required.
    RenderTargetBitmap frame = new RenderTargetBitmap((int)visual.ContentBounds.Width, (int)visual.ContentBounds.Height, 96, 96, PixelFormats.Pbgra32);
    frame.Render(visual);
    // Now encode the rendered target into Jpeg and output to a file.
    JpegBitmapEncoder jpeg = new JpegBitmapEncoder();
    jpeg.Frames.Add(BitmapFrame.Create(frame));
    using (System.IO.Stream fs = System.IO.File.Create(String.Format(saveFormat, pageIndex)))
    {
        jpeg.Save(fs);
    }
