    // Conditional Locking concept code
    
    namespace SystemExtensions {
    public static class LockMeUp
    {
      private static bool isLockingEnabled = true;
      // If set to true, locking will be performed
      // by the extension methods below.
      internal static bool LockingEnabled
      {
        get
        {
          return isLockingEnabled;
        }
        set
        {
          isLOckingEnbaled = value;
        }
      }
      static void CheckNull<TLock>( TLock target ) where TLock: class
      {
        if( target == null )
          throw new ArgumentNullException("target cannot be null");
      }
      // Invoke the supplied action on the supplied lock object
      public static void TryLock<TLock>( 
        this TLock target, 
        Action<TLock> action ) where TLock: class
      {
        CheckNull( target );
        if( isLockingEnabled )
        {
          lock( target )
          {
            action( target );
          }
        }
        else
        {
          action( target );
        }
      }
      // Invoke the supplied function on the supplied 
      // lock object and return result:   
      public static T TryLock<TLock, T>( 
        this TLock target, 
        Func<TLock, T> func ) where TLock: class
      {
        CheckNull( target );
        if( isLockingEnabled )
        {
          lock( target )
          {
            return func( target );
          }
        }
        else
        {
          return func( target );
        }
      }
      // Invoke the supplied funtion on the supplied lock object 
      // and another supplied argument, and return the result:    
      public static T TryLock<TLock, TArg, T>( 
        this TLock target, 
        Func<TLock, TArg, T> func, 
        TArg arg ) where TLock: class
      {
        CheckNull( target );
        if( isLockingEnabled )
        {
          lock( target )
          {
            return func( target, arg );
          }
        }
        else
        {
          return func( target, arg );
        }
      }
      // Invoke the supplied action on the supplied lock object 
      // and another supplied argument:   
      public static void TryLock<TLock, TArg>( 
        this TLock target, 
        Action<TLock, TArg> func, 
        TArg arg )  where TLock: class
      {
        CheckNull( target );
        if( isLockingEnabled )
        {
          lock( target )
          {
            func( target, arg );
          }
        }
        else
        {
          func( target, arg );
        }
      } 
    }
    ///// Example:
    public static class SharedList<T>
    {
      private static List<T> items = new List<T>();
      public static bool Remove( T item )
      {
        return items.TryLock( (list, item) => list.Remove( item ), item );
      }
      public static T GetItemAt( int index )
      {
        return items.TryLock( (list, i) => list[i], index );
      }
      public static bool Contains( T item )
      {
        return items.TryLock( (list, it) => list.Contains( it ), item );
      }
      public static void Add( T item )
      {
        items.TryLock( (list, item) => list.Add( item ) );
      }
    }
    } // namespace
