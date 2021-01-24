    [assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
    namespace App15.iOS
    {
        public class CustomSearchBarRenderer : SearchBarRenderer
        {
            UIImage defaultIcon = null;
            protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
            {
                base.OnElementChanged(e);
                if(null != Control)
                {
                    var searchBar = this.Control as UISearchBar;
                    defaultIcon = defaultIcon ?? searchBar.GetImageForSearchBarIcon(UISearchBarIcon.Search, UIControlState.Normal); //This will save the default icon
    
                    searchBar.OnEditingStarted += delegate
                    {
                        searchBar.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Search, UIControlState.Normal);
                    };
    
                    searchBar.OnEditingStopped += delegate
                    {
                        searchBar.SetImageforSearchBarIcon(defaultIcon, UISearchBarIcon.Search, UIControlState.Normal);
                    };
                }
            }
        }
    }
