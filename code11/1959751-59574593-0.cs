    public async static Task<BitmapImage> ImageFromBytes(Byte[] bytes)
    {
        BitmapImage image = new BitmapImage();
        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
        {
            await stream.WriteAsync(bytes.AsBuffer());
            stream.Seek(0);
            await image.SetSourceAsync(stream);
        }
        return image;
    }
