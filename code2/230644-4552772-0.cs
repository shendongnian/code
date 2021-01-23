    public static void StartTcpListener(TcpListener listener)
    {
        try
        {
            listener.Server.Blocking = false;
            listener.BeginAcceptTcpClient(
                ar =>
                {
                    TcpClient client = listener.EndAcceptTcpClient(ar);
                },
                listener);
        }
        catch
        {
            // catch exceptions on close, e.g.
        }
    }
