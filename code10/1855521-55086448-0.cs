                ConnectionOptions options = new ConnectionOptions();
                ManagementScope scope = new ManagementScope(@"\\servername\root\cimv2", options);
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    
                        if (m["Started"].Equals(true))
                        {
                            m.InvokeMethod("StopService", null);
                        }
                    
                }
