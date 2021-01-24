    using Quobject.EngineIoClientDotNet.Client.Transports;
    using Quobject.SocketIoClientDotNet.Client;
    
    
    
         var option = new IO.Options()
                    {
                      QueryString = "Type=Desktop",
                      Timeout = 5000,
                      ReconnectionDelay = 5000,
                      Reconnection = false,                   
                      ransports = Quobject.Collections.Immutable.ImmutableList.Create<string>(PollingXHR.NAME)
                    };
                 
                    socket = IO.Socket("http://localhost:1453",option);
                    socket.On(Socket.EVENT_CONNECT, () =>
                    {
                        socket.Emit("iAmOnline", "1234");
    
                    });
                    socket.On("youAreOnline", () =>
                    {
                        Console.WriteLine("I am Online");
                    });
    
                    socket.On("hi", (data) =>
                    {
                        Console.WriteLine(data);
                        socket.Disconnect();
                    });
