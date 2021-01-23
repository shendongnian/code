    class MyDictionary<TKey,TValue>:IDictionary<TKey,TValue>
    {
      private Dictionarty<TKey,TValue> backingDictionary;
    
      //Implement the interface here
      //Delegating most of the logic to your backingDictionary
      ...
    }
