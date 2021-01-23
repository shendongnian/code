    public static string PingHost(string host)
    {
        //string to hold our return messge
        string returnMessage = string.Empty;
     
        //IPAddress instance for holding the returned host
        IPAddress address = GetIpFromHost(ref host);
     
        //set the ping options, TTL 128
        PingOptions pingOptions = new PingOptions(128, true);
     
        //create a new ping instance
        Ping ping = new Ping();
     
        //32 byte buffer (create empty)
        byte[] buffer = new byte[32];
     
        //first make sure we actually have an internet connection
        if (HasConnection())
        {
            //here we will ping the host 4 times (standard)
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    //send the ping 4 times to the host and record the returned data.
                    //The Send() method expects 4 items:
                    //1) The IPAddress we are pinging
                    //2) The timeout value
                    //3) A buffer (our byte array)
                    //4) PingOptions
                    PingReply pingReply = ping.Send(address, 1000, buffer, pingOptions);
     
                    //make sure we dont have a null reply
                    if (!(pingReply == null))
                    {
                        switch (pingReply.Status)
                        {
                            case IPStatus.Success:
                                returnMessage = string.Format("Reply from {0}: bytes={1} time={2}ms TTL={3}", pingReply.Address, pingReply.Buffer.Length, pingReply.RoundtripTime, pingReply.Options.Ttl);
                                break;
                            case IPStatus.TimedOut:
                                returnMessage = "Connection has timed out...";
                                break;
                            default:
                                returnMessage = string.Format("Ping failed: {0}", pingReply.Status.ToString());
                                break;
                        }
                    }
                    else
                        returnMessage = "Connection failed for an unknown reason...";
                }
                catch (PingException ex)
                {
                    returnMessage = string.Format("Connection Error: {0}", ex.Message);
                }
                catch (SocketException ex)
                {
                    returnMessage = string.Format("Connection Error: {0}", ex.Message);
                }
            }
        }
        else
            returnMessage = "No Internet connection found...";
     
        //return the message
        return returnMessage;
    }
