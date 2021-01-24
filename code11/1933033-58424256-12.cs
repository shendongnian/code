    [assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
    namespace App15.iOS
    {
        public class CustomSearchBarRenderer : SearchBarRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
            {
                base.OnElementChanged(e);
                if(null != Control)
                {
                    Control.OnEditingStarted += Control_OnEditingStarted;
                    Control.OnEditingStopped += Control_OnEditingStopped;
                }
            }
    
            private void Control_OnEditingStopped(object sender, EventArgs e)
            {
                var searchBar = sender as UISearchBar;
                searchBar.SetImageforSearchBarIcon(searchBar.GetImageForSearchBarIcon(UISearchBarIcon.Search, UIControlState.Normal), UISearchBarIcon.Search, UIControlState.Normal);
            }
    
            private void Control_OnEditingStarted(object sender, EventArgs e)
            {
                var searchBar = sender as UISearchBar;
                searchBar.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Search, UIControlState.Normal);
            }
        }
    }
