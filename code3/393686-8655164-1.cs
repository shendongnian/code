       private Region _region;
       DocumentPane _regionTarget
       protected override void Adapt(IRegion region, DocumentPane regionTarget)
        {
            _region = region;
            _regionTarget = regionTarget;
            region.Views.CollectionChanged += OnCollectionChanged;
        }
        
        private void OnCollectionChanged (object sender, NotifyCollectionChangedEventArgs e) 
        {
            OnViewsCollectionChanged(sender, e, _region, _regionTarget);
        }
    
        ...
        private void Unsubscribe() 
        {
          _region.Views.CollectionChanged -= OnCollectionChanged;
        }
