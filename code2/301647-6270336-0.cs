    using System.IO.Ports;
    ...
    
    SerialPort port1 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
    SerialPort port2 = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
      
    port1.DataReceived += new SerialDataReceivedEventHandler(port1_DataReceived);
    port2.DataReceived += new SerialDataReceivedEventHandler(port2_DataReceived);
    port1.Open();
    port2.Open();
    ...
    private void port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        // Show all the incoming data in the port's buffer
        Console.WriteLine(port1.ReadExisting());
    }
    private void port2_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        // Show all the incoming data in the port's buffer
        Console.WriteLine(port2.ReadExisting());
    }
