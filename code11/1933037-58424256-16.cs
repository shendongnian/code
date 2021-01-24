    [assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
    namespace App15.iOS
    {
        public class CustomSearchBarRenderer : SearchBarRenderer
        {
            UIImage searchImg;
            protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
            {
                base.OnElementChanged(e);
                searchImg = Control.GetImageForSearchBarIcon(UISearchBarIcon.Search, UIControlState.Normal);
                if (e.OldElement != null)
                {
                    Control.OnEditingStarted -= Control_OnEditingStarted;
                    Control.OnEditingStopped -= Control_OnEditingStopped;
                }
    
                if (e.NewElement != null)
                {
                    if (null != Control)
                    {
                        Control.OnEditingStarted += Control_OnEditingStarted;
                        Control.OnEditingStopped += Control_OnEditingStopped;
                    }
                }
            }
    
            private void Control_OnEditingStopped(object sender, EventArgs e)
            {
                var searchBar = sender as UISearchBar;
                searchBar.SetImageforSearchBarIcon(searchImg, UISearchBarIcon.Search, UIControlState.Normal);
            }
    
            private void Control_OnEditingStarted(object sender, EventArgs e)
            {
                var searchBar = sender as UISearchBar;
                searchBar.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Search, UIControlState.Normal);
            }
        }
    }
