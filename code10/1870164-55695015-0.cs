    public class Modbus
    {
        public delegate void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e);
        public event SerialDataReceivedEventHandler DataReceived;
        private readonly SerialPort modbusPort; // CHANGED THIS LINE
    
        public Modbus(int baudRate, string port)
        {
            modbusPort = new SerialPort();
    
            modbusPort.BaudRate = baudRate;
            modbusPort.PortName = port;
            modbusPort.Open();
    
            modbusPort.DataReceived += Incoming;
        }
    
        private void Incoming (object sender, SerialDataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                SerialDataReceivedEventArgs rea = new SerialDataReceivedEventArgs { Data = e.Data };
                DataReceived(this, rea);
            }
        }
    }
