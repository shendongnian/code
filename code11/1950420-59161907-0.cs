    static async Task<XDocument> LoadXmlAsync(string path)
    {
        using (var file = System.IO.File.OpenRead(path))
        {
            var doc = await XDocument.LoadAsync(file, LoadOptions.None, System.Threading.CancellationToken.None);
            return doc;
        }
    }
