    private string GetPortAsString()
              {
                 // Parsing
                 System.Runtime.Remoting.Channels.IChannel[] channels = System.Runtime.Remoting.Channels.ChannelServices.RegisteredChannels;
                 foreach (System.Runtime.Remoting.Channels.IChannel c in channels)
                 {
                    System.Runtime.Remoting.Channels.Tcp.TcpChannel tcp = c as System.Runtime.Remoting.Channels.Tcp.TcpChannel;
                    if (tcp != null)
                    {
                       System.Runtime.Remoting.Channels.ChannelDataStore store = tcp.ChannelData as System.Runtime.Remoting.Channels.ChannelDataStore;
                       if (store != null) // Do something
                       {
                          foreach (string s in store.ChannelUris)
                          {
                             Uri uri = new Uri(s);
                             return uri.Port.ToString(); // There should only be one, and regardless the port should be the same even if there are others in this list.
                          }
                       }
                    }
                 }
        
                 return string.Empty;
              }
