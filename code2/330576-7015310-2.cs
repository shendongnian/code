    private Image ProcestaImageButtonImage
    {
        get
        {
            var template = ProcestaImageButton.Template
                                    .FindName("ButtonImage", ProcestaImageButton);
            return (Image) template;
        }
    }
    public ImageSource ButtonImage
    {
        get { return ProcestaImageButtonImage.Source; }
        set { ProcestaImageButtonImage.Source = value; }
    }
