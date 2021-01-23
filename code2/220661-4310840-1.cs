    try {
            listener.Bind(localEP);
            listener.Listen(10);
    
            while (true) {
                allDone.Reset();
    
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(
                    new AsyncCallback(SocketListener.acceptCallback), 
                    listener );
    
                allDone.WaitOne();
            }
        } catch (Exception e) {
