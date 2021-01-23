     public static string ReadMessage(int index)
        {
            using (SerialPort sp = new SerialPort(_portNumber))
            {
                sp.Open();
                sp.Write("AT+CMGR=" + index + "\r");
                
                Thread.Sleep(2000);
                
                return sp.ReadExisting();
            }
        }
