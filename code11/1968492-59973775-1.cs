    using(Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync())
    {
       if (stream != null)
       {
          // save stream data as an byte array 
          _streamData = ReadBytes(stream);
          ItemPic = (StreamImageSource)ImageSource.FromStream(() => stream);
       }
    }
    // a helper method to get the stream data
    private byte[] ReadBytes(Stream input)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
    // a helper method to create an image from an byte array
    private ImageSource GetImageSource(byte[] data)
    {
       return ImageSource.FromStream(() => new MemoryStream(data)
    }
