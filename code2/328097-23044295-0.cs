    public static string SendBackProcessorName()
            {
                ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                string Procname = null;
    
                foreach (ManagementObject moProcessor in mosProcessor.Get())
                {
                    if (moProcessor["name"] != null)
                    {
                        Procname = moProcessor["name"].ToString();
                        
                    }
    
                }
    
                return Procname;
            }
