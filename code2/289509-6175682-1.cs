    public string IPList()
            {
                var pingSender = new Ping();
                string port = string.Empty;
                string myipsplit = string.Empty;
                string localhostname = Dns.GetHostName();
                IPAddress[] paddresses = Dns.GetHostAddresses(localhostname);
                string myip = paddresses[0].ToString();
                string[] myiparray = myip.Split(new[] {'.'});
                for (int j = 1; j < myiparray.Length; j++)
                    myipsplit += myiparray[j - 1] + ".";
                Trace.WriteLine(DateTime.Now);
                for (int i = 0; i < 0x100; i++)
                {
                    string ls = myipsplit + i;
                    PingReply reply = pingSender.Send(ls, 0);
                    if (reply != null)
                        if (reply.Status == IPStatus.Success)
                            port += reply.Address + "+";
                }
                Trace.WriteLine(DateTime.Now);
                return port;
            }
