    class Caller
    {
      private Listener listener;
      LetItStop()
      {
         listener.SendMessage(new StopMessage());
      }
    }
