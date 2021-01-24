    async void OnButtonClicked(object sender, EventArgs args)
    {
        // Show ActivityIndicator here
    
        using (var image = args.Surface.Snapshot())
        using (var data = image.Encode(SKEncodedImageFormat.Png, 80))
        using (var stream = File.OpenWrite(Path.Combine("MyApp.TempImages", "1.png")))
        {
            var dataStream = data.AsStream();
            await dataStream.CopyTo(stream);
            await stream.FlushAsync();
        }
    
        // Hide ActivityIndicator here
    }
