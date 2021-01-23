            portNumber = Int32.Parse(s.Remove(0, 3));
            // MUST BE LOCAL
            var serialOneOfMany = new SerialPort(s, baudRate, Parity.None, 8, StopBits.One);
            serialOneOfMany.ReadTimeout = 2000;
            serialOneOfMany.WriteTimeout = 2000;
            if (serialOneOfMany.IsOpen)
            {
                serialOneOfMany.Close();
            }
            // timer must be defined _after_ serialOneOfMany
            var interval = 3000; // ms 
            var timer = new System.Timers.Timer(interval);
            timer.Elapsed += (o, e) =>
            {
                timer.Enabled = false;
                if (serialOneOfMany.IsOpen)
                    serialOneOfMany.Close();  // may not be necessary with Dispose? 
                serialOneOfMany.Dispose();
                timer.Dispose();
            };     
