    public class ViewData : INotifyPropertyChanged
    {
        private string _FeedTitle;
        private RssItem _SelectedItem = null;
        private ObservableCollection<RssItem> _feedItems = new ObservableCollection<RssItem>();
    
        private const string MyRssfeed = "http://feeds.bbci.co.uk/news/rss.xml";
    
        public ViewData()
        {
            RssService.GetRssItems(
                MyRssfeed,
                (title, items) =>
                {
                    App.Current.RootVisual.Dispatcher.BeginInvoke(() =>
                    {
                        FeedTitle = title;
                        FeedItems = new ObservableCollection<RssItem>(items);
                    });
                },
                (exception) =>
                {
                    MessageBox.Show(exception.Message);
                },
                null);
        }
    
        public ObservableCollection<RssItem> FeedItems
        {
            get { return _feedItems; }
            set
            {
                if (_feedItems == value)
                    return;
                _feedItems = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("FeedItems"));
            }
        }
    
        public string FeedTitle
        {
            get { return _FeedTitle; }
            set
            {
                if (_FeedTitle == value)
                    return;
                _FeedTitle = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("FeedTitle"));
            }
        }
    
        public RssItem SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem == value)
                    return;
                _SelectedItem = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(sender, args);
        }
    }
