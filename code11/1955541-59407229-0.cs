    public static Stream ConvertImage(this Stream originalStream, ImageFormat format)
    {
                    var image = Image.FromStream(originalStream);
    
                   using(var stream = new MemoryStream())
              {
                    image.Save(stream, format);
                    stream.Position = 0;
                    return stream;
              }
        }
