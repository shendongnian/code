        static System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
        private static int defaultBaudRate = 9600, defaultDataBits = 8;
        static System.IO.Ports.SerialPort TryOpeningPort(string portName)
        {
            System.IO.Ports.SerialPort port = null;
            timer.Start();
            try
            {
                port = new System.IO.Ports.SerialPort(portName,
                    defaultBaudRate, System.IO.Ports.Parity.None, defaultDataBits, System.IO.Ports.StopBits.One);
                port.Open();
                port.Close();
                /**/Console.WriteLine(portName + " : OK");
            }
            catch (Exception exceptionInfo) //most common is System.UnauthorizedAccessException
            {
                port = null;
                /**/Console.WriteLine(portName + " -- " + exceptionInfo.GetType().ToString() + " : " + exceptionInfo.Message);
            }
            timer.Stop();
            //Console.WriteLine("Elapsed time : " + timer.ElapsedMilliseconds + "ms" + System.Environment.NewLine);
            timer.Reset();
            return port;
        }
