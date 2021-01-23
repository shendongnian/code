    class GenericOjbect<T>
    {
      public T Value2 {get;private set;}
      public GenericOjbect( T val ) {Value2 = val;}
      public bool Equals( T val )
      {
        return Value2.Equals( val );
      }
      public override bool Equals( object obj )
      {
        if ( obj is T )
        {
          return this.Equals( ( T )obj );
        }
        if (obj != null && obj is GenericOjbect<T> )
        {
          return this.Equals( ( obj as GenericOjbect<T> ).Value2 );
        }
        return base.Equals( obj );
      }
    }
