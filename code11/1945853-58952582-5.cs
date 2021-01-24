    public class HexConvert
    {
        SerialPort mySerialPort;
        public HexConvert()
        {
            InitPort();
        }
        void InitPort()
        {
            mySerialPort = new SerialPort("COM1");
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
        }
        public void SendMessage()
        {
            try
            {
                string s = "15"; // "F" In Hexadecimal
                int x = Int32.Parse(s);
                string s2 = x.ToString("X");
                if(!mySerialPort.IsOpen)
                    mySerialPort.Open();
                mySerialPort.WriteLine(s2);
                mySerialPort.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
