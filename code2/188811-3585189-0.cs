    public ImageSource MyImage
    {
        get
        {
            if (this.IsImageFit)
                return .....;   // return an ImageSource using your image
            else
                return null;
        }
    }
