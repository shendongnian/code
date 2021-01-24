    private bool HostPingable(string host)
        {
            try
            {
                var ping = new Ping();
                var reply = ping.Send(host);
                return reply != null && reply.Status == IPStatus.Success;
            }
            catch (Exception e)
            {
                e.LogException(Logger, host);
            }
            finally { GC.Collect(); }
            return false;
        }
