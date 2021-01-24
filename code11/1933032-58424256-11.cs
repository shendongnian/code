    [assembly: ResolutionGroupName("MyCompany")]
    [assembly: ExportEffect(typeof(App15.iOS.SearchBarEffect), "SearchBarEffects")]
    namespace App15.iOS
    {
        public class SearchBarEffect : PlatformEffect
        {
            protected override void OnAttached()
            {
                ((UISearchBar)Control).OnEditingStarted += SearchBar_OnEditingStarted;
                ((UISearchBar)Control).OnEditingStopped += SearchBar_OnEditingStopped;
            }
    
            private void SearchBar_OnEditingStopped(object sender, EventArgs e)
            {
                var searchBar = sender as UISearchBar;
                searchBar.SetImageforSearchBarIcon(searchBar.GetImageForSearchBarIcon(UISearchBarIcon.Search, UIControlState.Normal), UISearchBarIcon.Search, UIControlState.Normal);
            }
    
            private void SearchBar_OnEditingStarted(object sender, EventArgs e)
            {
                var searchBar = sender as UISearchBar;
                searchBar.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Search, UIControlState.Normal);
            }
    
            protected override void OnDetached()
            {
                ((UISearchBar)Control).OnEditingStarted -= SearchBar_OnEditingStarted;
                ((UISearchBar)Control).OnEditingStopped -= SearchBar_OnEditingStopped;
            }
        }
    }
