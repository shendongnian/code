    StringBuilder sbScale = new StringBuilder();
    StringBuilder sbPLC = new StringBuilder();
    char LF = (char)10;
    
    private void serialPortScale_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPortScale.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == LF)
            {
                sbScale.Append(c);
    
                CurrentLine = sbScale.ToString();
                sbScale.Clear();
    
                ReadDataFromScale(CurrentLine);
            }
            else
            {
                sbScale.Append(c);
            }
        }
    }
    
    private void serialPortPLC_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPortPLC.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == LF)
            {
                sbPLC.Append(c);
    
                CurrentLine = sbPLC.ToString();
                sbPLC.Clear();
    
                ReadDataFromPlc(CurrentLine);
            }
            else
            {
                sbPLC.Append(c);
            }
        }
    }
