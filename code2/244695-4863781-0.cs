    public static void SaveImageStream(this HttpContextBase ctx, string filename)
    {
        var config = ObjectFactory.GetInstance<IConfig>();
        using (var reader = new BinaryReader(ctx.Request.InputStream))
        {
            var bandImagesPath = config.GetSetting<string>("BandImagePath");
            var path = Path.Combine(ctx.Server.MapPath(bandImagesPath), filename);
            using (var outputStream = System.IO.File.Create(path, 2048))
            {
                const int chunkSize = 2 * 1024; // 2KB
                byte[] buffer = new byte[chunkSize];
                int bytesRead;
                ctx.Request.InputStream.Position = 0;
                while ((bytesRead = ctx.Request.InputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputStream.Write(buffer, 0, bytesRead);
                }
            }
            ctx.Request.InputStream.Position = 0;
            ctx.GenerateThumbnail(filename);
        }
    }
