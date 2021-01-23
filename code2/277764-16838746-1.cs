    public bool IsConnected(Socket s)
    {
        try
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("test");
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        catch (Exception)
        {
            throw new LostConnection();
        }
        return s.Connected;
    }
