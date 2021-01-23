    private Image ProcestaImageButtonImage
    {
        get
        {
            var template = ProcestaImageButton.Template
                                    FindName("ButtonImage", ProcestaImageButton);
            return template as Image;
        }
    }
    public ImageSource ButtonImage
    {
        get { return ProcestaImageButtonImage.Source; }
        set { ProcestaImageButtonImage.Source = value; }
    }
