    private ICollectionView messageListView;
    public ICollectionView MessageListView
    {
        get { return this.messageListView; }
        private set
        {
          if (value == this.messageListView)
          {
            return;
          }
          this.messageListView = value;
          this.NotifyOfPropertyChange(() => this.MessageListView);
        }
    }
   
    ...
 
    this.MessageListView = CollectionViewSource.GetDefaultView(this.ImportMessageList);
    this.MessageListView.Filter = new Predicate<object>(this.FilterMessageList);
    ...
    public bool FilterMessageList(object item)
    {
      // inspect item as message here, and return true 
      // for that object instance to include it, false otherwise
      return true;
    }
