    public abstract class ManagedEventCollection<T> : IList<T>
    {
       public ManagedEventCollection()
       {
          m_list = new ObservableCollection<T> ();
          m_list.CollectionChanged += CollectionChanged;
       }
       ... // Add/Remove/Indexer/Clear methods alter contents of m_list.
       protected abstract void OnItemAdded(T item);
       protected abstract void OnItemRemoved(T item);
    
       private ObservableCollection<T> m_list;
       private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs ea)
       {
          foreach (T item in ea.NewItems)
             OnItemAdded(item);
          foreach (T item in ea.OldItems)
             OnItemRemoved(item);
       }
    }
