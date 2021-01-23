     public static void Main()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("The following serial ports were found:");
            // Display each port name to the console.
            foreach(string port in ports)
            {
                Console.WriteLine(port);
            }
            Console.ReadLine();
        }
