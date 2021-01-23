    protected override void Adapt(IRegion region, DocumentPane regionTarget)
    {
        region.Views.CollectionChanged += OnCollectionChanged;
    }
    
    private void OnCollectionChanged (object sender, NotifyCollectionChangedEventArgs e) 
    {
        OnViewsCollectionChanged(sender, e, region, regionTarget);
    }
    ...
    private void Unsubscribe() 
    {
      region.Views.CollectionChanged -= OnCollectionChanged;
    }
