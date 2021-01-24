    public void Handle_Button(object sender, System.EventArgs e)
    {
        var fileName = "someFile.txt";
        using (var stream = File.Create(Path.Combine(FileSystem.CacheDirectory, fileName)))
        {
           // just creating a dummy file to copy (in the cache dir using Xamarin.Essentials
        }
        var downloadPath = DependencyService.Get<IDownloadPath>().Get();
        File.Copy(Path.Combine(FileSystem.CacheDirectory, fileName), downloadPath);
    }
