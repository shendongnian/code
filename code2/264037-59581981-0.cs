    var serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
     try
     {
         while (true)
         {
             serialPort.ReadTimeout = 2000;
             if (!serialPort.IsOpen) serialPort.Open();
             int readData = serialPort.ReadByte();
             Console.Write((char)readData);
         }
     }
     catch (Exception ex)  // Press CTRL-C to exit.
     {
         Console.WriteLine(ex.Message);
         Console.ReadKey();
     }
     serialPort.Close();
