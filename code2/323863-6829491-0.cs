    private ArrayList IPList()
            {
                string myipsplit = string.Empty;
                string myip =
                    Dns.GetHostAddresses(
                        Dns.GetHostName())[0].ToString();
                string[] myiparray = myip.Split(new[] {'.'});
                for (int j = 1; j < myiparray.Length; j++)
                    myipsplit += myiparray[j - 1] + ".";
                var sb = new ArrayList();
                MyPing ping = delegate(int id)
                                  {
                                      string ls = myipsplit + id;
                                      var pingSender = new System.Net.NetworkInformation.Ping();
                                      PingReply reply = pingSender.Send(ls, 0);
                                      if (reply != null)
                                          if (reply.Status == IPStatus.Success)
                                              sb.Add(ls);
                                  };
                var asyncResults = new IAsyncResult[0x100];
                for (int i = 1; i < 0x100; i++)
                    asyncResults[i] = ping.BeginInvoke(i, null, null);
                for (int i = 1; i < 0x100; i++)
                    ping.EndInvoke(asyncResults[i]);
                return sb;
            }
    
            #region Nested type: MyPing
    
            private delegate void MyPing(int id);
    
            #endregion
