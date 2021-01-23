    server.ImageDownloaded += (s, e) =>
    {
        lock (Cache)
        {
            Cache.Add(e.Bitmap, e.Name);
        }
        onGetImage(e.Bitmap);
    }
