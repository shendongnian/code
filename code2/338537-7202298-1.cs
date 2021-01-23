    class ObservableCollectionAdapterBase 
    {
      virtual void Method1(){}
      virtual void Method2(){}
    }
    class ObservableCollectionAdapter<T, TCollectionType> : ObservableCollectionAdapterBase 
    where TCollectionType : IObservableCollection<T> 
    {
       public ObservableCollectionAdapter(TCollectionType collection)
       {
          _collection = collection;
       }
       override void Method1(){ _collection.DoSomething(); }
       override void Method2(){ _collection.DoSomething(); }
    }
