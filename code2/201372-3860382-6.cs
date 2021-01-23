    public void logLine(string line)
    {
        rtxtLoginMessage.Select(0, 0);    
        rtxtLoginMessage.SelectedText = line + Enviroment.NewLine;
    } 
