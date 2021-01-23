    static void Main(string[] args)
            {
                RDP();
                while(true)
                {
                    if(Process.GetProcessesByName("mstsc").Length == 0)
                     RDP();
    				Thread.sleep(300);///Use any value which is confortable with you're request
                }
            }
    
            private static void RDP()
            {
                Process rdp = new Process();
                rdp.StartInfo = new ProcessStartInfo("C:\\Alistair\\Default.rdp");
                rdp.Start();
            }
