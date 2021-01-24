     public BitmapImage Image
                {
                    get { return _image; }
                    set
                    {
                        _image = value;
                        RaisePropertyChanged();
                    }
                }
         public byte[] Thumbprint
                {
                    get { return _thumbprint; }
                    set
                    {
                        _thumbprint = value;
                        if (value != null)
                        {
                            ConvertToBitMapImageAsync(value);
                        }
                        RaisePropertyChanged();
                    }
                }
     public async Task<BitmapImage> ConvertToBitMapImageAsync(byte[] bytes)
            {
                if (bytes != null)
                {
                    Image = new BitmapImage();
                    var stream = bytes?.AsBuffer()?.AsStream()?.AsRandomAccessStream();
                    await Image.SetSourceAsync(stream);
                    return Image;
                }
                return null;
            }
    
     
