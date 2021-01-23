    RenderTargetBitmap DrawToImage<T>(T source, double scale) where T:FrameworkElement
    {
        var clone = Clone(source);
        clone.Width = clone.Height = Double.NaN;
        clone.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        clone.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        clone.Margin = new Thickness();
        var size = new Size(source.ActualWidth * scale, source.ActualHeight * scale);
        clone.Measure(size);
        clone.Arrange(new Rect(size));
        var renderBitmap = new RenderTargetBitmap((int)clone.ActualWidth, (int)clone.ActualHeight, 96, 96, PixelFormats.Pbgra32);
        renderBitmap.Render(clone);
        return renderBitmap;
    }
    static T Clone<T>(T source) where T:UIElement
    {
        if (source == null)
            return null;
        string xaml = XamlWriter.Save(source);
        var reader = new StringReader(xaml);
        var xmlReader = XmlTextReader.Create(reader, new XmlReaderSettings());
        return (T)XamlReader.Load(xmlReader);
    }
