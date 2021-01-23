    class MyMessageHandler
    {
      ctor MyMessageHandler()
      {
        Messager.Default.Register<Message>( this, Handle );
      }
      void Handle( Message msg )
      {
        //Do something
      }
    }
