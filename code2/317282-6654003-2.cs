    public abstract class ManagedEventCollection<T,TEventArgs> : IList<T>
    {
       private EventInfo m_event;
       public ManagedEventCollection(string eventName)
       {
          m_list = new ObservableCollection<T> ();
          m_list.CollectionChanged += CollectionChanged;
          m_event = typeof (T).GetEvent (eventName);
       }
       // Add/Remove/Indexer/Clear methods alter contents of m_list.
       public EventHandler<TEventArgs> Handler{get;set;}
       protected abstract void OnItemAdded(T item);
       protected abstract void OnItemRemoved(T item);
    
       private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs ea)
       {
          foreach (T item in ea.NewItems)
          {
             m_event.AddEventHandler (
                item, 
                Delegate.CreateDelegate (m_event.EventHandlerType, item, Handler.Method));
          }
          foreach (T item in ea.OldItems)
          {
             m_event.RemoveEventHandler (
                item, 
                Delegate.CreateDelegate (m_event.EventHandlerType, item, Handler.Method));
          }
       }
    }
