    public async Task<ImageSource> getImageSource(string url)
        {
            byte[] byteArray = Client.DownloadData(url);
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }
