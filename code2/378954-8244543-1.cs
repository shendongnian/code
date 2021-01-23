    using System.Management;
    using System.Linq;
    
    namespace DisableNIC
    {
        internal static class Program
        {
            private static void Main()
            {
                var wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter " +
                                                "WHERE NetConnectionId != null " +
                                                  "AND Manufacturer != 'Microsoft' ");
                using (var searcher = new ManagementObjectSearcher(wmiQuery))
                {
                    foreach (var item in searcher.Get().OfType<ManagementObject>())
                    {
                        if ((string) item["NetConnectionId"] != "Local Area Connection")
                            continue;
    
                        using (item)
                        {
                            item.InvokeMethod("Disable", null);
                        }
                    }
                }
            }
        }
    }
