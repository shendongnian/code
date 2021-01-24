    using System;
    using System.IO.Ports;
    
    class Moneris_Integration
    {
        public static void Main()
        {
            SerialPort port = new SerialPort("COM4");
    
            port.BaudRate = 19200;
            port.Parity = Parity.Even;
            port.StopBits = StopBits.One;
            port.DataBits = 7;      // Changed to 7. Was incorrectly told it was 8.
    
            port.Open();
    
            // You'll need to change this to be whatever your app is trying to send at the time
            // Last array item is the LRC. In my case, it was 0x31
            var bytesToSend = new byte[] { 0x02, 0x30, 0x30, 0x1c, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x1c, 0x30, 0x30, 0x32, 0x30, 0x03, 0x31 };
    
            port.Write(bytesToSend, 0, bytesToSend.Length);
    
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    
            Console.ReadKey();
        }
    
        public static byte calculateLRC(byte[] bytes)
        {
            byte LRC = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i == 0)
                {
                    LRC = bytes[i];
                }
                else
                {
                    LRC ^= bytes[i];
                }
    
            }
            return LRC;
        }
    
        private static void DataReceivedHandler(
        object sender,
        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string incomingData = sp.ReadExisting();
            Console.WriteLine("Response:");
            Console.Write(incomingData);
        }
    }
