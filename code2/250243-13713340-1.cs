    public const string ImageStreamPropertyName = "ImageStream";
    private Stream _imageStream = null;
    public Stream ImageStream
    {
        get
        {
            return _imageStream;
        }
        set
        {
            if (_imageStream == value)
            {
                return;
            }
            _imageStream = value;
            RaisePropertyChanged(ImageStreamPropertyName);
            // Raise for ImageSource too since it changes with ImageStream
            RaisePropertyChanged("ImageSource");
        }
    }
    public ImageSource ImageSource
    {
        get
        {
            if (ImageStream == null)
                return null;
            return (ImageSource)new ImageSourceConverter().ConvertFrom(ImageStream);
        }
    }
