    public async Task<List<string>> CommunicationJob(string port, int boud, List<string> sendPkt)
    {
        string openResult = OpenPort(port, boud);
        string recvMsg = "";
        ....
        List<string> recvs = new List<string>();
    
        for (int i = 0; i < sendPkt.Count; i++)
        {
            recvMsg = await SendAndRecv(sendPkt[i]); // <--- note this line!
            Trace.WriteLine("recvMsg : " + recvMsg);
            recvs.Add(recvMsg);
        }
    
        return recvs;
    }
