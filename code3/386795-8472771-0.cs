    Timer myTimer = new Timer(500);
    timer1.Interval = 5000;
    timer1.Enabled = true;
    timer1.Tick += new System.EventHandler (OnTimerEvent);
    
    Write the event handler
    
    This event will be executed after every 5 secs.
    
    public static void OnTimerEvent(object source, EventArgs e)
    {
    m_streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
    m_streamWriter.Flush();
    }
    
    
    
  
  
