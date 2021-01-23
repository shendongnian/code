    using (var output = new FileStream(outputPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
    {
       var imageDecoder = BitmapDecoder.Create(inputStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
       var imageFrame = imageDecoder.Frames[0];
        
       decimal aspect = (decimal)imageFrame.Width / (decimal)imageFrame.Height;
       var height = (int)(newWidth / aspect);
        
       var imageResized = new TransformedBitmap(imageFrame,new ScaleTransform(
                                                                     newWidth / imageFrame.Width * Dpi / imageFrame.DpiX,
                                                                     height / imageFrame.Height * Dpi / imageFrame.DpiY, 0, 0));
        
       var targetFrame = BitmapFrame.Create(imageResized);
        
       var targetEncoder = new JpegBitmapEncoder();
       targetEncoder.Frames.Add(targetFrame);
       targetEncoder.QualityLevel = 80;
       targetEncoder.Save(output);
    }
