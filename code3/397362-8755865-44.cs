    private ResourceDictionary _viewDictionary = new ResourceDictionary();
    
    public ResourceDictionary Dict
    {
        get
        {
            return _viewDictionary;
        }
    }
    
    _viewDictionary.Source =
                    new Uri("/MyExtension.Test;component/View.xaml",
                    UriKind.RelativeOrAbsolute);
