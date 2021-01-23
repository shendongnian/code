        private void Form1_Load(object sender, EventArgs e)
        {
            sp = new SerialPort("COM1", 19200, Parity.Space, 8, StopBits.One);
            sp.ParityReplace = 0;
            sp.ErrorReceived += new SerialErrorReceivedEventHandler(sp_SerialErrorReceivedEventHandler);
            sp.Encoding = Encoding.GetEncoding(28591);
            sp.Open();
        }
        SerialPort sp;
        string msg;
        public void sp_SerialErrorReceivedEventHandler(Object sender, SerialErrorReceivedEventArgs e)
        {
            if (e.EventType == SerialError.RXParity)
            {
               msg = sp.ReadExisting();
            }
        }
        string strToByteArray(string str) 
        {
            Encoding enc = Encoding.GetEncoding(28591);                     
            byte[] bytes = enc.GetBytes(str);
            return BitConverter.ToString(bytes);
        } 
  
