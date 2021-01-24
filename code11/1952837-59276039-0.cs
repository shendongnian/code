    char ETX = (char)4;
    StringBuilder sb = new StringBuilder();
    string currentLine = string.Empty;
    
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPort1.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == ETX)
            {
                sb.Append(c);
    
                CurrentLine = sb.ToString();
                sb.Clear();
    
                //parse CurrentLine here or print it to textbox
    			//note you might have to invoke becasue this event is on its own thread
            }
            else
            {
                sb.Append(c);
            }
        }
    }
