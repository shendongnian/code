    private async Task btnRead_Click(object sender, EventArgs e)
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
