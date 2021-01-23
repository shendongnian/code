    class MyCollection<T>
    {
      private T[] data;
      private int size;
      
      public MyCollection()
      {
        data=new T[4];
      }
    
      public int Size{get{return size;}}
      public int Capacity{get{return data.Length;}}
      [ContractInvariantMethod]
      protected void ClassInvariant()
      {
        Contract.Invariant(data != null);
        Contract.Invariant(Size >= 0);
        Contract.Invariant(Capacity >= 0);
        Contract.Invariant(Size < Capacity);
      }
    }
