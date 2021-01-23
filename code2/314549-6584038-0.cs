    // Base for ALL view models implements necessary interfaces.
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
      // Functionality useful to ALL view models
      public string DisplayName { get; }
      // etc.
      ...
    }
    
    // Generic collection view model implementing functionality required by
    // all collection view models.
    public abstract class CollectionViewModel<T> : BaseViewModel
    {
        public abstract ObservableCollection<T> Items { get; set; }
    }
    
    // Specific collection view model using generic one through composition
    public class PersonCollectionViewModel : BaseViewModel
    {
        public CollectionViewModel<Person> PersonCollection { get; }
        // other functionality not included in all collection view models.
        // ...
    }
