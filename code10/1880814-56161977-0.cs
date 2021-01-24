    static System.Timers.Timer Timer1;
    void button1_Click(object sender, EventArgs e)
    {
         Timer1 = new System.Timers.Timer(60*60*1000);
         Timer1.Elapsed += new ElapsedEventHandler(TimedEvent);
         Timer1.Enabled = true;
    
         WriteToSerialPort();
    
    }
    private void TimedEvent(Object source, ElapsedEventArgs e)
    {
         WriteToSerialPort();
    }
    private void WriteToSerialPort()
    {
         serialPort1.Write("high");
    }
