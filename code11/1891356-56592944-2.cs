    public async Task<List<string>> CommunicationJob(string port, int boud, List<string> sendPkt)
    {
        string openResult = OpenPort(port, boud);
        string recvMsg = "";
        ....
        List<string> recvs = new List<string>();
    
        for (int i = 0; i < sendPkt.Count; i++)
        {
            recvMsg = await SendAndRecv(sendPkt[i]);
            Trace.WriteLine("recvMsg : " + recvMsg);
            recvs.Add(recvMsg);
        }
    
        return recvs;
    }
    private async void btnRead_Click(object sender, EventArgs e)
    {
        SendPkt.Clear();
        RecvPkt.Clear();
    
        C_Serial c_serial = new C_Serial();
    
        Trace.WriteLine("start : "+DateTime.Now);
    
        RecvPkt = await c_serial.CommunicationJob(Port, Baud, SendPkt);
    
        for (int i = 0; i < RecvPkt.Count; i++)
            Trace.WriteLine(RecvPkt[i]);
    
        Trace.WriteLine("end : "+DateTime.Now);
    }
