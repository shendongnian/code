    WordsView = new CollectionViewSource();
    WordsView.Filter += Words_Filter;
    WordsView.Source = Words;
    // ...
    void Words_Filter(object sender, FilterEventArgs e)
    {
        if (e.Item != null)
            e.Accepted = ((string)e.Item).Contains(":");
    }
