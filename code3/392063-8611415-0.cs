        private ushort BindToNextAvail(Socket sock, params ushort[] portList)
        {
            foreach (ushort i in portList)
            {
                try
                {
                    sock.Bind(new IPEndPoint(IPAddress.Any, i));
                    return (ushort)((IPEndPoint)sock.LocalEndPoint).Port;
                }
                catch
                {
                    Logger.Instance().WriteLog(EventLogEntryType.Warning, "Unable to use port " + i.ToString());
                }
            }
            return 0;
        }
