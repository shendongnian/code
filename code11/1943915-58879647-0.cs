    public async Task<byte[]> ReadPdfFileAsync()
    {
        using (var fileStream = Assets.Open("pdf-file.pdf")
        using (var memoryStream = new MemoryStream())
        {
            await fileStream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
