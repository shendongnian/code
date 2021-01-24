        static System.Windows.Forms.Timer timer1;
        void button1_Click(object sender, EventArgs e)
        {
                 timer1 = new System.Windows.Forms.Timer(60*60*1000);
                 timer1.Tick += Timer1_Tick;
                 timer1.Enabled = true;
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
