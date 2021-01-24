    async Task<Android.Graphics.Bitmap> GetBitmapFromUrlAsync(string url)
    {
        var handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip
        };
        using (var client = new HttpClient(handler))
        {
            var response = await client.GetAsync(url);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    return await BitmapFactory.DecodeStreamAsync(stream);
                }
            }
            return null;
        }
    }
