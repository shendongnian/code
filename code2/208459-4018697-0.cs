     public TextWriter Log { get; set; }
    
     private void WriteToLog(string Message)
     {
        if (Log != null) Log.WriteLine(message);
     }
