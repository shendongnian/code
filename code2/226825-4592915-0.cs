        //using System.Management;
        private void GetPrinterProperties(object sender, EventArgs e)
        {
            // SelectQuery from:
            //    http://msdn.microsoft.com/en-us/library/ms257359.aspx
            // Build a query for enumeration of instances
            var query = new SelectQuery("Win32_Printer");
            // instantiate an object searcher
            var searcher = new ManagementObjectSearcher(query); 
            // retrieve the collection of objects and loop through it
            foreach (ManagementObject lPrinterObject in searcher.Get())
            {
                string lProps = GetWmiPrinterProperties(lPrinterObject);
                // some logging, tracing or breakpoint here...
            }
        }
    
        // log PrinterProperties for test-purposes
        private string GetWmiPrinterProperties(ManagementObject printerObject)
        {
            // Win32_Printer properties from:
            //    http://msdn.microsoft.com/en-us/library/aa394363%28v=VS.85%29.aspx
            return String.Join(",", new string[] {
                    GetWmiPropertyString(printerObject, "Caption"),
                    GetWmiPropertyString(printerObject, "Name"),
                    GetWmiPropertyString(printerObject, "DeviceID"),
                    GetWmiPropertyString(printerObject, "PNPDeviceID"),
                    GetWmiPropertyString(printerObject, "DriverName"),
                    GetWmiPropertyString(printerObject, "Portname"),
                    GetWmiPropertyString(printerObject, "CurrentPaperType"),
                    GetWmiPropertyString(printerObject, "PrinterState"),
                    GetWmiPropertyString(printerObject, "PrinterStatus"),
                    GetWmiPropertyString(printerObject, "Location"),
                    GetWmiPropertyString(printerObject, "Description"),
                    GetWmiPropertyString(printerObject, "Comment"),
                });
        }
    
        private string GetWmiPropertyString(ManagementObject mgmtObject, string propertyName)
        {
            if (mgmtObject[propertyName] == null)
            {
                return "<no "+ propertyName + ">";
            }
            else
            {
                return mgmtObject[propertyName].ToString();
            }
        }
    }
