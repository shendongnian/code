    StringBuilder sb = new StringBuilder();
    
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPort1.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == '\r')
            {
                sb.Append(c);
    
                CurrentLine = sb.ToString();
                sb.Clear();
    
                SampleFactory sampleFactory = new SampleFactory(CurrentLine, new SampleTypeExtractor());
    			OnSampleReady(sampleFactory.GetSample());
            }
            else
            {
                sb.Append(c);
            }
        }
    }
