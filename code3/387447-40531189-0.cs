    public static class ObservableCollectionExtension
    {
        public static void NotifyPropertyChanged<T>(this ObservableCollection<T> observableCollection, Action<T, PropertyChangedEventArgs> callBackAction)
            where T : INotifyPropertyChanged
        {
            observableCollection.CollectionChanged += (sender, args) =>
            {
                //Does not prevent garbage collection says: http://stackoverflow.com/questions/298261/do-event-handlers-stop-garbage-collection-from-occuring
                //publisher.SomeEvent += target.SomeHandler;
                //then "publisher" will keep "target" alive, but "target" will not keep "publisher" alive.
                if (args.NewItems == null) return;
                foreach (T item in args.NewItems)
                {
                    item.PropertyChanged += (obj, eventArgs) =>
                    {
                        callBackAction((T)obj, eventArgs);
                    };
                }
            };
        }
    }
    public void ExampleUsage()
    {
        var myObservableCollection = new ObservableCollection<MyTypeWithNotifyPropertyChanged>();
        myObservableCollection.NotifyPropertyChanged((obj, notifyPropertyChangedEventArgs) =>
        {
            //DO here what you want when a property of an item in the collection has changed.
        });
    }
