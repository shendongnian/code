    public ImageSource ButtonImage
    {
        get
        { 
            var template = ProcestaImageButton.Template
                                    .FindName("ButtonImage", ProcestaImageButton);
            var image = template as Image;
            return image.Source;
        }
        set
        {
            var template = ProcestaImageButton.Template
                                    .FindName("ButtonImage", ProcestaImageButton);
            var image = template as Image;
            image.Source = value;
        }
    }
