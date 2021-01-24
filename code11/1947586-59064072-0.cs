        public static async System.Threading.Tasks.Task RunAsync([BlobTrigger("image/{name}", Connection = "AzureWebJobsStorage")]CloudBlockBlob inputBlob,
                [Blob("resized/{name}", FileAccess.Write)] CloudBlockBlob outputBlob, string name, ILogger log)
            {
                
                if (!inputBlob.Metadata.ContainsKey("Resized") || inputBlob.Metadata["Resized"] == bool.FalseString)
                {
                    var inputBlobStream = await inputBlob.OpenReadAsync();
                    System.IO.MemoryStream blobstream = new System.IO.MemoryStream();
                   
                    using (var image = Image.Load(inputBlobStream))
                    {
                        
                        image.Mutate(x => x.Resize(1920, 1080));
                        image.Save(blobstream , new JpegEncoder());
                        
                        blobstream.Seek(0, SeekOrigin.Begin);
                        await outputBlob.UploadFromStreamAsync(blobstream);
    
                        // If comment next statements, everything is ok, otherwise - it's not saving correctly
                        inputBlob.Metadata["ResizedFHD"] = bool.TrueString;
                        await inputBlob.SetMetadataAsync();
                    }
                    
                }
