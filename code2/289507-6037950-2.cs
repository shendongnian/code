    private delegate void MyPing(int id);
            public string IPList2()
            {
                
                string myipsplit = string.Empty;
                string localhostname = Dns.GetHostName();
                IPAddress[] paddresses = Dns.GetHostAddresses(localhostname);
                string myip = paddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
                string[] myiparray = myip.Split(new[] { '.' });
                for (int j = 1; j < myiparray.Length; j++)
                    myipsplit += myiparray[j - 1] + ".";
                Trace.WriteLine(DateTime.Now);
                var results = new string[0x100];
                MyPing ping = 
                 id =>
                {
                    string ls = myipsplit + id;
                    var pingSender = new Ping();
                    PingReply reply = pingSender.Send(ls, 100);
                    if (reply != null)
                        if (reply.Status == IPStatus.Success)
                            results[id] = reply.Address.ToString();
                };
                var asyncResults = new IAsyncResult[0x100];
                for (int i = 1; i < 0x100; i++)
                {
                    asyncResults[i] = ping.BeginInvoke(i, null, null);
                }
                for (int i = 1; i < 0x100; i++)
                {
                    ping.EndInvoke(asyncResults[i]);
                }
                Trace.WriteLine(DateTime.Now);
                var sb = new StringBuilder();
                for (int i = 1; i < 0x100; i++)
                {
                    if (results[i]!=null)
                        sb.AppendFormat("{0} ", results[i]);
                }
                return sb.ToString();
            }
