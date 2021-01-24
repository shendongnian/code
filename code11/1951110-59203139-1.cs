    char LF = (char)10;
    StringBuilder sb = new StringBuilder();
    string currentLine = string.Empty;
    
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
    
                //parse CurrentLine here or print it to textbox
            }
            else
            {
                sb.Append(c);
            }
        }
    }
