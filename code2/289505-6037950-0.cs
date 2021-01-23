    public string IPList()
            {
                var pingSender = new Ping();
                string myipsplit = string.Empty;
                string localhostname = Dns.GetHostName();
                IPAddress[] paddresses = Dns.GetHostAddresses(localhostname);
                string myip = paddresses.Where( ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
                string[] myiparray = myip.Split(new[] { '.' });
                for (int j = 1; j < myiparray.Length; j++)
                    myipsplit += myiparray[j - 1] + ".";
                Trace.WriteLine(DateTime.Now);
                var results = new string[0x100];
                System.Threading.Tasks.Parallel.For(1, 0x100, id =>
                               {
                                  string ls = myipsplit + id;
                                  PingReply reply = pingSender.Send(ls, 100);
                                  if (reply != null)
                                        if (reply.Status == IPStatus.Success)
                                            results[id] = reply.Address.ToString();
                                });
    
                Trace.WriteLine(DateTime.Now);
                var sb = new StringBuilder();
                results.All(x => { sb.AppendFormat("{0} ", x);
                                     return true;
                });
                return sb.ToString();
            }
