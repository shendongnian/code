    public BitmapImage Source
            {
                get
                {
    
       string strURI = (string)GetValue(CustomImagePlaceHolder.ImageUri);
                    return new BitmapImage(new Uri(strURI));
                }
                set
    {
    SetValue(CustomImagePlaceHolder.ImageUri, value);
     }
    
            }
