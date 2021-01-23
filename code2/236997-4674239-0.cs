    public class searchForm 
    {
        public event EventHandler<SearchEventArgs> SearchResultSelected = delegate { };
    }
    public class SearchEventArgs : EventArgs
    {
        public int Index { get; set; }
    }
    searchForm sf = new searchForm(_QPCollection);
    sf.SearchResultSelected += (s, e) => MyListView.SelectedIndex = e.Index;
