    public async Task UploadStream(Stream stream)
    {
        using (stream)
        {
            //save the image under the Uploads folder on the server-side(root directory).
            using (var file = File.Create(Path.Combine(HostingEnvironment.MapPath("~/Uploads"), Guid.NewGuid().ToString() + ".jpg")))
            {
                await stream.CopyToAsync(file);
            }
        }
    }
