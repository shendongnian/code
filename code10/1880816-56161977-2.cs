    static System.Timers.Timer Timer1;
    void button1_Click(object sender, EventArgs e)
    {
         Timer1 = new System.Timers.Timer(60*60*1000);
         Timer1.Elapsed += new ElapsedEventHandler(TimedEvent);
         Timer1.Enabled = true;
    
         WriteToSerialPort(); // Call method directly for writing to port.
    
    }
    private void TimedEvent(Object source, ElapsedEventArgs e)
    {
         WriteToSerialPort(); // call method to write to port when time elapses
    }
    private void WriteToSerialPort()
    {
         serialPort1.Write("high"); // write to port
    }
    
    
    // Instead try this.
    
        static System.Windows.Forms.Timer timer1;
        void button1_Click(object sender, EventArgs e)
            {
        
                 Timer1 = new System.Windows.Forms.Timer(60*60*1000);
                 Timer1.Elapsed += new ElapsedEventHandler(TimedEvent);
                 Timer1.Enabled = true;
            
                 WriteToSerialPort(); // Call method directly for writing to port.
            
            }
        
        private void timer1_Tick(object sender, EventArgs e)
            {
                 WriteToSerialPort(); 
            }
            private void WriteToSerialPort()
            {
                 serialPort1.Write("high"); // write to port
            }
