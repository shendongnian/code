    // Set timeout on the socket
    m_receiver.Client.ReceiveTimeout = 5000;
    try
    {
        IAsyncResult ir = m_receiver.BeginReceive(null, null);
        m_receivedBytes = m_receiver.EndReceive(ir, m_receiver.Client.RemoteEndPoint);
        // process received bytes here
    }
    catch (SocketException)
    {
        // Timeout or some other error happened.
    }
