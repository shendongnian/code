      private SerialPort KickerPort { get; set; }
        .
        .
        .
    private bool OpenPort()
            {
                //https://stackoverflow.com/questions/7219653/why-is-access-to-com-port-denied
                //due to a bug in the SerialPort code, the serial port needs time to dispose if we used this recently and then closed
                //therefore the "open" could fail, so put in a loop trying for a few times
                int sleepCount = 0;
                while (!TryOpenPort())
                {
                    System.Threading.Thread.Sleep(100);
                    sleepCount += 1;
                    System.Diagnostics.Debug.Print(sleepCount.ToString());
                    if (sleepCount > 50) //5 seconds should be heaps !!!
                    {
                        throw new Exception(String.Format("Failed to open kicker USB com port {0}", KickerPort.PortName));
                    }
                }
                return true;
            }
         private bool TryOpenPort()
                    {
                        if (!KickerPort.IsOpen)
                        {
                            try
                            {
                                KickerPort.Open();
                                return true;
                            }
                            catch (UnauthorizedAccessException)
                            {
                                return false;
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
            
                        }
                        return true;
                    }
