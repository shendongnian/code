    public static async Task ParseFiles(
        Stream data, string contentType, Action<string, Stream> fileProcessor)
    {
        var streamContent = new StreamContent(data);
        streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        var provider = await streamContent.ReadAsMultipartAsync();
        foreach (var httpContent in provider.Contents)
        {
            var fileName = httpContent.Headers.ContentDisposition.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
            {
                continue;
            }
            using (Stream fileContents = await httpContent.ReadAsStreamAsync())
            {
                fileProcessor(fileName, fileContents);
            }
        }
    }
