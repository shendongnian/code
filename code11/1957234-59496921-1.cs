    namespace ConsoleApplication_ReadTabel
    {
        class SerialPortProgram
        {
            private SerialPort port; 
            string input = "";
            [STAThread]
            static void Main(string[] args)
            {
                new SerialPortProgram();
            }
            private SerialPortProgram()
            {
                port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                Console.WriteLine("Incoming Data:");
                port.DataReceived += new
                SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.Write("ghghgh");
                Console.Read();//when program is here, send something the port and continue
            
                Thread.Sleep(5000);
                Console.Read();
            }
            private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                input = port.ReadLine();
                Console.WriteLine(input);
                Console.WriteLine("----");
            }
        }
    }
