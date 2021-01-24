    public async Task UploadStream(Stream stream)
            {
                using (stream)
                {
                    using (var file = File.Create(Path.Combine(HostingEnvironment.MapPath("~/Uploads"), Guid.NewGuid().ToString() + ".png")))
                    {
                        await stream.CopyToAsync(file);
                    }
                }
            }
