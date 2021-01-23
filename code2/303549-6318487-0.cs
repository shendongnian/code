    [Serializable]
    public abstract class ModelCollection<TModel> : ModelCollectionBase,
    	IList<TModel>, IList, INotifyCollectionChanged, INotifyPropertyChanged
    	where TModel : ModelBase<TModel>
    {
    	private ObservableCollection<TModel> wrappedCollection = new ObservableCollection<TModel>();
    
    	// wrapper implementation goes here
    }
