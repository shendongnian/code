    class GenericOjbect<T>
    {
      public T Value {get;private set;}
      public GenericOjbect( T val ) {Value = val;}
      public bool Equals( T val )
      {
        return Value.Equals( val );
      }
      public override bool Equals( object obj )
      {
        if ( obj is T )
        {
          return this.Equals( ( T )obj );
        }
        if (obj != null && obj is GenericOjbect<T> )
        {
          return this.Equals( ( obj as GenericOjbect<T> ).Value );
        }
        return base.Equals( obj );
      }
    }
