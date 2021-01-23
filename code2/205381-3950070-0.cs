    private Dispatcher _dispatcher;
    
    public NetworkSession()
    {
       _dispatcher = Dispatcher.CurrentDispatcher;
    }
    
    //any thread can call this method
    public void DoStuff()
    {
       Action action = () =>
       {
          ChatWindow temp = new ChatWindow(split[2], split[3]);
          Chats.Add(temp);
          temp.Show();
       }
    
       _dispatcher.BeginInvoke(action);
    }
