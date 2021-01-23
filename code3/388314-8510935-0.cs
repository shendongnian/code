    public class Terminal : IDisposable
    {
      List<IListener> _listeners;
      List<Action<string>> _sources;
      public Terminal(IEnumerable<IListener> listeners)
      {
          _listeners = new List<IListener>(listeners);
          _sources = new List<Action<string>>();
      }
      public void Subscribe(ref Action<string> source)
      {
          _sources.Add( source );
          source += Broadcast;
      }
      void Broadcast(string message)
      {
          foreach (var listener in _listeners) listener.Listen(message);
      }
      public void Dispose()
      {
          foreach ( var s in _sources ) s -= Broadcast; 
      }
    }
