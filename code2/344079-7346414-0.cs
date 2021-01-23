    static void Main(string[] args)
            {
                RDP();
                while(true)
                {
                    foreach (Process clsProcess in Process.GetProcesses())
                    {
                        if (!clsProcess.ProcessName.Contains("mstsc.exe"))
                        {
    						RDP();
    						break;
                        }
                    }
    				Thread.sleep(300);///Use any value which is confortable with you're request
                }
            }
    
            private static void RDP()
            {
                Process rdp = new Process();
                rdp.StartInfo = new ProcessStartInfo("C:\\Alistair\\Default.rdp");
                rdp.Start();
            }
