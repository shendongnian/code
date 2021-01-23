    class MyGenericClass<T> where T : ICompareable
    {
      private List<T> data = new List<T>();
    
      public AddData(params T[] values)
      {
          data.AddRange (values);
      }
      public RemoveData( T value )
      {
         data.Remove (value);
      }
      public RemoveData( params T[] values )
      {
          for( int i = 0; i < values.Length; i++ ) 
          {
              data.Remove (values[i]);
          }
      }
    }
