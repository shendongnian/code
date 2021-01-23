    class CompareByIndex : IComparer
    {
        private readonly ListView _listView;
        public CompareByIndex(ListView listView)
        {
            this._listView = listView;
        }
        public int Compare(object x, object y)
        {
            int i = this._listView.Items.IndexOf((ListViewItem)x);
            int j = this._listView.Items.IndexOf((ListViewItem)y);
            return i - j;
        }
    }
