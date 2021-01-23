        class clsRS232 : IDisposable
        {
            private SerialPort myPort;
            public clsRS232()
            {
                myPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            }
            public void OpenPort()
            {
                myPort.Open();
            }
            public void SendFunc(string str)
            {
                myPort.Write(str);
            }
            public string ReadFunc()
            {
               return  myPort.ReadExisting();
            }
    
            public void Dispose()
            {
                myPort.Dispose();
            }
    
        }
    
