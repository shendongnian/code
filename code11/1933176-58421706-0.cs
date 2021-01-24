    var image = Xamarin.Forms.Image();
    var assembly = this.GetType().GetTypeInfo().Assembly;
    byte[] imgByteArray = null;
    using (var s = assembly.GetManifestResourceStream("my_image_source.png"))
    {
        if (s != null)
        {
            var length = s.Length;
            imgByteArray = new byte[length];
            s.Read(buffer, 0, (int)length);
           image.Source = ImageSource.FromStream(() => s);
        }
    }
    // here imageByteArray will have the bytes from the image file or it will be null if the file was not loaded.
    if (imgByteArray != null)
    {
       //use your data here.
    }
