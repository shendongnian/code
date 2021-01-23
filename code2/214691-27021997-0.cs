     string GetDomainName()
        {
            string _domain = IPGlobalProperties.GetIPGlobalProperties().DomainName;
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(_domain);
                if (reply.Status == IPStatus.Success)
                {
                    return _domain;
                }
                else
                {
                    return reply.Status.ToString();
                }
            }
            catch (PingException pExp)
            {
                if (pExp.InnerException.ToString() == "No such host is known")
                {
                    return "Network not detected!";
                }
                return "Ping Exception";
            }
        }
