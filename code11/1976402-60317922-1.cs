    private readonly HttpClient httpClient = new HttpClient();
    private async void timer_Tick(object sender, EventArgs e)
    {
        var uri = "http://0.0.0.0/api/camera/snapshot?width=640&height=480";
        using (var responseStream = await httpClient.GetStreamAsync(uri))
        using (var memoryStream = new MemoryStream())
        {
            await responseStream.CopyToAsync(memoryStream); // ensure full download
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = memoryStream;
            image.EndInit();
            img.Source = image;
        }
    }
