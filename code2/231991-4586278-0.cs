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
    }
