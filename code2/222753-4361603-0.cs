    public static bool IsConnected()
    {
        try
        {
            var entry = Dns.GetHostEntry("www.google.com");
            return true;
        }
        catch (SocketException ex)
        {
            return false;
        }
    }
