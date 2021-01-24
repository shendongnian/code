    public void SavePicture(Label label)
    {
        var path = "label.png";
    
        var width = label.Width;
        var height = label.Height;
    
        var viewBox = new Viewbox();
        var renderTargetBitmap = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
        var pngBitmapEncoder = new PngBitmapEncoder();
    
        viewBox.Child = label;
        viewBox.Measure(new Size(width, height));
        viewBox.Arrange(new Rect(0, 0, width, height));
        viewBox.UpdateLayout();
    
        renderTargetBitmap.Render(viewBox);
    
        pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
    
        using (var fileStream = File.Create(path))
        {
            pngBitmapEncoder.Save(fileStream);
        }
    }
