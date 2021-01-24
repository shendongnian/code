    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO.Ports;
    namespace ConsoleApplication108
    {
        class Program
        {
           static void Main(string[] args)
            {
                string[] names = SerialPort.GetPortNames();
            }
        }
     
    }
