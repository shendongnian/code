    public async Task UploadStream(Stream stream)
            {
                MultipartParser parser = new MultipartParser(stream);
    
                if (parser.Success)
                {
                    //absolute filename, extension included.
                    var filename = parser.Filename;
                    var filetype = parser.ContentType;
                    var ext = Path.GetExtension(filename);
                    using (var file = File.Create(Path.Combine(HostingEnvironment.MapPath("~/Uploads"), Guid.NewGuid().ToString() +ext)))
                    {
                        await file.WriteAsync(parser.FileContents, 0, parser.FileContents.Length);
                    }
                }
            }
     
