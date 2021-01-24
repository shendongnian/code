    public async Task UploadStream(Stream stream)
            {
                var context = WebOperationContext.Current;
                string filename = context.IncomingRequest.Headers["filename"].ToString();
                string ext = Path.GetExtension(filename);
                using (stream)
                {
                    //save the image under the Uploads folder on the server-side(root directory).
                    using (var file = File.Create(Path.Combine(HostingEnvironment.MapPath("~/Uploads"), Guid.NewGuid().ToString() + ext)))
                    {
                        await stream.CopyToAsync(file);
                    }
                }
            }
