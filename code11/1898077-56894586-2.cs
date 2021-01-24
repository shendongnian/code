    async Task<string> ReadInitialKey(string path)
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(path);
            Windows.Storage.FileProperties.MusicProperties musicProperties = await file.Properties.GetMusicPropertiesAsync();
            var props = await musicProperties.RetrievePropertiesAsync(null);
            var inkp = props["System.Music.InitialKey"];
            return (string)inkp;
        }
