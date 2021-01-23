    public void Receive(Socket s)
    {
        try
        {
            byte[] bytes = new byte[256];
            received = s.Receive(bytes);
            receivedText.Text += System.Text.ASCIIEncoding.ASCII.GetString(bytes);
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return;
        }
    }
