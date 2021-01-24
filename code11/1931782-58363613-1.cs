    private void LoadTextureImage(string imagePath)
    {
        var syncContext = SynchronizationContext.Current;
        OnBytesLoaded callback = new OnBytesLoaded(bytes => syncContext .Post(_ => LoadBytesToTexture(bytes), null));
        System.Threading.ThreadPool.QueueUserWorkItem(o =>
        {
            byte[] bytes = System.IO.File.ReadAllBytes(imagePath);
            Debug.Log($"Loaded image bytes");
            callback?.Invoke(bytes);
        });
    }
