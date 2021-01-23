    static string GetBatteryStatus() {
        ManagementScope scope = new ManagementScope("//./root/cimv2");
        SelectQuery query = new SelectQuery("Select BatteryStatus From Win32_Battery");
        using(ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query)) {
            using(ManagementObjectCollection objectCollection = searcher.Get()) {
                foreach(ManagementObject mObj in objectCollection) {
                    PropertyData pData = mObj.Properties["BatteryStatus"];
                    switch((Int16)pData.Value) { 
                        //...
                        case 2:return "Not Charging";
                        case 3:return "Fully Charged";
                        case 4:return "Low";
                        case 5: return "Critical";
                        //...
                    }
                }
            }
        }
        return string.Empty;
    }
