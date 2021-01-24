    using (var page = document.GetPage(i))
    {
        var stream = new InMemoryRandomAccessStream();
        await page.RenderToStreamAsync(stream);
        BitmapImage src = new BitmapImage();
        Output.Source = src; // pass bitmapImage to Source
        await src.SetSourceAsync(stream);
        stream.Dispose();
        result.Add(src);
    }
