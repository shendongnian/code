    public Page(string _setLayout, string _imageURL, string _setTitleText, string _setDescriptionText)
    {
        InitializeComponent();
        if (!string.IsNullOrEmpty(_imageURL))
        {
            MyImage.Source = new BitmapImage(new Uri(_imageURL));
        }
        if (string.IsNullOrEmpty(_imageURL))
        {
            MyImage.Source = new BitmapImage(new Uri("Some\path\to\default\image.png"));
        }            
    }
