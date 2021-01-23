    public void listenForPeers()
    {
      //Setup the server socket
    
      while(true){
        Socket newClient = serverSock.Accept();
        if(newClient.Connected){
          Thread tc = new Thread(new ParameterizedThreadStart(listenclient));
          tc.start(newClient);
        }
      }
    }
    
    void listenclient(object clientSockObj)
    {
      Socket clientSock = (Socket)clientSockObj;
    
      //communication to client via clientSock.
    }
