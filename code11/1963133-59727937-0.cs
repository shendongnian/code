    public async Task UploadImagesAsync(IFormFileCollection files, int VehicleID)
        {
       
           foreach (var file in files)
            {
           var extension = Path.GetExtension(file.FileName);
                        var encoder = GetEncoder(extension);
            if (encoder != null)
                        {
              
                            using (var output = new MemoryStream())
                            using (Image<Rgba32> image = Image.Load(input))
                            {
                                var divisor = image.Width / thumbnailWidth;
                                var height = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));
    
                                image.Mutate(x => x.Resize(thumbnailWidth, height));
                                image.Save(output, encoder);
                                output.Position = 0;
                                await blockBlob.UploadFromStreamAsync(output);
                            }
          }
       }
    }
    
    private static IImageEncoder GetEncoder(string extension)
            {
                IImageEncoder encoder = null;
    
                extension = extension.Replace(".", "");
    
                var isSupported = Regex.IsMatch(extension, "gif|png|jpe?g", RegexOptions.IgnoreCase);
    
                if (isSupported)
                {
                    switch (extension)
                    {
                        case "png":
                            encoder = new PngEncoder();
                            break;
                        case "jpg":
                            encoder = new JpegEncoder();
                            break;
                        case "jpeg":
                            encoder = new JpegEncoder();
                            break;
                        case "gif":
                            encoder = new GifEncoder();
                            break;
                        default:
                            break;
                    }
                }
