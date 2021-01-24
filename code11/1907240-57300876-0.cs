public void SendToMultiple(IPAddress[] Recipients, byte[] Data)
{
    Parallel.ForEach(Recipients,
        Recipient =>
        {
            UdpClient Client = new UdpClient();
            Client.Send(Data, Data.Length, new IPEndPoint(Recipient, PORT));
            Client.Close();
        });
}
