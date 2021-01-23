            String server = String.Empty;
            // For each printer installed on this computer
            foreach (string printerName in PrinterSettings.InstalledPrinters) {
                // Build a query to find printers named [printerName]
                string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
                // Use the ManagementObjectSearcher class to find Win32_Printer's that meet the criteria we specified in [query]
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection coll = searcher.Get();
                // For each printer (ManagementObject) found, iterate through all the properties
                foreach (ManagementObject printer in coll) {
                    foreach (PropertyData property in printer.Properties) {
                        // Get the server (or IP address) from the PortName property of the printer
                        if (property.Name.Equals("PortName")) {
                            server = property.Value as String;
                            Console.WriteLine("Server for " + printerName + " is " + server);
                        }
                    }
                }
            }
