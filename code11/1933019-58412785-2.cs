    public class NoSearchIconEffect : PlatformEffect
    {
        UIImage defaultIcon = null;
        protected override void OnAttached()
        {
            var searchBar = this.Control as UISearchBar;
            defaultIcon = defaultIcon ?? searchBar.GetImageForSearchBarIcon(UISearchBarIcon.Search, UIControlState.Normal); //This will save the default icon
            searchBar.OnEditingStarted += (s, e) =>
            {
                searchBar.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Search, UIControlState.Normal);
            };
            searchBar.OnEditingStopped += delegate
            {
                searchBar.SetImageforSearchBarIcon(defaultIcon, UISearchBarIcon.Search, UIControlState.Normal);
            };
        }
        protected override void OnDetached()
        {
            
        }
    }
