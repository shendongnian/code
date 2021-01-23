    public class MyMonostateSingletonList : IList<int>
    {
      private static readonly IList<int> instance = new List<int>() ;
        
      public MyMonostateSingletonList()
      {
        return ;
      }
      public int IndexOf( int item )
      {
        return instance.IndexOf(item) ;
      }
      public void Insert( int index , int item )
      {
        instance.Insert( index , item ) ;
      }
      public void RemoveAt( int index )
      {
        instance.RemoveAt( index ) ;
      }
      public int this[int index]
      {
        get
        {
          return instance[index] ;
        }
        set
        {
          instance[index] = value ;
        }
      }
      public void Add( int item )
      {
        instance.Add(item) ;
      }
      public void Clear()
      {
        instance.Clear() ;
      }
      public bool Contains( int item )
      {
        return instance.Contains(item) ;
      }
      public void CopyTo( int[] array , int arrayIndex )
      {
        instance.CopyTo( array , arrayIndex ) ;
      }
      public int Count
      {
        get { return instance.Count ; }
      }
      public bool IsReadOnly
      {
        get { return instance.IsReadOnly ; }
      }
      public bool Remove( int item )
      {
        return instance.Remove(item);
      }
      public IEnumerator<int> GetEnumerator()
      {
        return instance.GetEnumerator() ;
      }
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return instance.GetEnumerator() ;
      }
    }
