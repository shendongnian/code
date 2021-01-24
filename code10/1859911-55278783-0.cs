    public interface IReadOnlyObservableCollection<T> 
        : INotifyCollectionChanged, IReadOnlyCollection<T> { }
    public class ReadOnlyObservableCollectionAdapter<T> : IReadOnlyObservableCollection<T> 
    { 
        private ReadOnlyObservableCollection<T> _collection
        public ReadOnlyObservableCollectionAdapter(ReadOnlyObservableCollection<T> collection) 
        { 
            _collection = collection;
        }
        ... Add all your adaptive methods here, and expose this in your classes interface.
    }
    public interface IMyInter
    {
        IReadOnlyObservableCollection<Data> files { get; }
    }
