    class SerialPortProgram
    {
        private SerialPort port, port2;
        [STAThread]
        static void Main(string[] args)
        {
            new SerialPortProgram();
        }
        private SerialPortProgram()
        {
            port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port2 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);           
            port2.DataReceived += new SerialDataReceivedEventHandler(port2_DataReceived);
            port2.Open();
            port.Write("Hello!");
            Console.Read();
        }
        void port2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("COM4 incoming data:");
            Thread.Sleep(300);
            string inp = port2.ReadExisting();
            Console.WriteLine(inp);
            Console.WriteLine("----");
        }
    }
