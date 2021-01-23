    private void net_As_Receive(IAsyncResult iar)
    {
        var bytesRead = g_client_conn.EndReceive(iar);
        
        if (bytesRead != 0)
        {
            net_Data_Receive(Encoding.ASCII.GetString(g_bmsg, 0, bytesRead));
            check = false;
        }
        g_client_conn.BeginReceive(g_bmsg, 0, g_bmsg.Length, SocketFlags.None, new AsyncCallback(net_As_Receive), g_client_conn);
    }
