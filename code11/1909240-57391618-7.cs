    public async Task UploadStream(Stream stream)
    {
        MultipartParser parser = new MultipartParser(stream);
        if (parser.Success)
        {
            using (var file = File.Create(Path.Combine(HostingEnvironment.MapPath("~/Uploads"), Guid.NewGuid().ToString() + ".png")))
            {
                await file.WriteAsync(parser.FileContents, 0, parser.FileContents.Length);
            }
        }
    }
