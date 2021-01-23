    internal class Proxy : MarshalByRefObject
    {
        public void GetResponse(SocketInformation clientInfo, HttpRequest req)
        {
            Socket client = new Socket(clientInfo);
            foreach (byte[] bytes in toSend)
                client.Send(bytes);
            client.Close();
        }
    }
