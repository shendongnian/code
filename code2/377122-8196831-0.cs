    public class ConnectTo : IDisposable
    {
      public Connection CurrentConnection {get; private set;}
      public ConnectTo()
      {
        CurrentConnection = null;
        // Connect up to whatever.
      }
      #region IDisposable
      // Blah blah
      
      #endregion
    }
