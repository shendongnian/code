    public class ObservableDictionary<TKey, TVal>:IDictionary<TKey, TVal>, IObservable
    {
       private Dictionary<TKey, TVal> _data;
    
       //Implement IDictionary, using _data for storage and raising NotifyPropertyChanged
    }
