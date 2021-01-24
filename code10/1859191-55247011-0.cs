    class VirtualListCollectionView : ListCollectionView
    {
        VirtualCollection m_collection;
        public VirtualListCollectionView(VirtualCollection collection)
            : base(collection)
        {
            m_collection = collection;
        }
        protected override void RefreshOverride()
        {
            m_collection.SetSortInternal(SortDescriptions);
            // Notify listeners that everything has changed
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            // The implementation of ListCollectionView saves the current item before updating the search
            // and restores it after updating the search. However, DataGrid, which is the primary client
            // of this view, does not use the current values. So, we simply set it to "beforeFirst"
            SetCurrent(null, -1);
        }
    }
