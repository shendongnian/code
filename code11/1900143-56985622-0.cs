				try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Service");
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("DisplayName: {0}", queryObj["DisplayName"]);
                        Console.WriteLine("Name: {0}", queryObj["Name"]);
                        Console.WriteLine("PathName: {0}", queryObj["PathName"]);
                        Console.WriteLine("ProcessId: {0}", queryObj["ProcessId"]);
                        Console.WriteLine("-----------------------------------");
                    }
                }
                catch (ManagementException me)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + me.Message);
                }
