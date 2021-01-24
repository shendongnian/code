     public HttpResponseMessage Get()
    {
        var path = @"C:\Temp\Sample\background.jpg";
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        using(var stream = new FileStream(path, FileMode.Open)){        
            var image = Image.FromStream(stream);
            var memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        }
        return result;
    }
