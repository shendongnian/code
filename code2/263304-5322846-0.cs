    public static DependencyProperty DownloadPicProperty =
        DependencyProperty.Register("DownloadPic", typeof(byte[]), typeof(ImageControl));
    
    public byte[] DownloadPic
    {
        get { return (byte[])GetValue(DownloadPicProperty); }
        set { SetValue(DownloadPicProperty, value); }
    }
    ...
    ImageControl imageControl = ...;
    imageControl.DownloadPic = DownloadPicture();
