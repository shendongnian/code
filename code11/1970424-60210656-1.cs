    private async Task ResizeAndUploadImageAsync(Image<Rgba32> image, int maxWidth, string 
        fileName)
        {    
            using (var writeStream = new MemoryStream())
            {
                if (image.Width > maxWidth)
                {
                    var thumbScaleFactor = maxWidth / image.Width;
                    image.Mutate(i => i.Resize(maxWidth, image.Height * 
                        thumbScaleFactor));
                }
                image.SaveAsPng(writeStream);
                await storageService.UploadFileAsync(writeStream, fileName);
        }
    }
