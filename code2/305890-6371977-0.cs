      private Func<String, objectA> _callDoWorkAsync = DoWork;
      private static string DoWork( objectA strA )
      {
         return bla( strA );
      }
      private void Start( String a )
      {
         _callDoWorkAsync.BeginInvoke( a, callback, null );
      }
      private void callback( IAsyncResult ar )
      {
         objectA strA = (objectA) _callDoWorkAsync.EndInvoke( ar );
      }
