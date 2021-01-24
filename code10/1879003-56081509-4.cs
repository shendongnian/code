    public class SharedState
    {
      //--> singleton instance...
      static readonly SharedState current;
      //--> use static initializer to create the current instance...
      static SharedState( )
      {
        current = new SharedState();
      }
      //--> hide ctor...
      private SharedState(){}
      public static SharedState Current
      {
        get { return current; }
      }
      //--> all your shared state instance methods and properties go here...
      public string SomeString
      {
        get
        {
          return //...
        }
      }
    }
