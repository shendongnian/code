    char ACK = (char)6;
    char NAK = (char)21;
    char SOH = (char)1;
    char LF = (char)10;
    StringBuilder sb = new StringBuilder();
    
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPort1.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == LF)
            {
                sb.Append(c);
    
                CurrentLine = sb.ToString();
                sb.Clear();
    
                //parse CurrentLine here
            }
            if (c == ACK)
            {
                sb.Append("<ACK>");
            }
            else
            {
                sb.Append(c);
            }
        }
    }
