    [assembly: ResolutionGroupName("MyCompany")]
    [assembly: ExportEffect(typeof(App15.iOS.SearchBarEffect), "SearchBarEffects")]
    namespace App15.iOS
    {
        public class SearchBarEffect : PlatformEffect
        {
            UIImage defaultIcon = null;
            protected override void OnAttached()
            {
                //throw new NotImplementedException();
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
    
            protected override void OnDetached()
            {
                //throw new NotImplementedException();
            }
        }
    }
