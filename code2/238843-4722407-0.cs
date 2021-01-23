    public static class ObservableCollectionExtensions
    {
        public static IObservable<IEvent<NotifyCollectionChangedEventArgs>> 
            GetObservableChanges<T>(this ObservableCollection<T> collection)
        {
            return Observable.FromEvent<
                NotifyCollectionChangedEventHandler, NotifyCollectionChangedArgs>(
                    h => new NotifyCollectionChangedEventHandler(h),
                    h => collection.CollectionChanged += h,
                    h => collection.CollectionChanged -= h
                );
        }
        public static IObservable<T> GetObservableAddedValues<T>(
            this ObservableCollection<T> collection)
        {
            return collection.GetObservableChanges()
                .Where(evnt => evnt.EventArgs.Action == NotifyCollectionChangedAction.Add)
                .SelectMany(evnt => evnt.EventArgs.NewItems.Cast<T>());
        }
    }
