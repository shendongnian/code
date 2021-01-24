    [WMIClass("UWF_Filter")]
        public class UnifiedWriteFilter : WMIInstance
        {
            [WMIProperty("CurrentEnabled")]
            public bool IsEnabled { get; set; }
        }
        public void IsWriteFilterEnabled()
        {
            WMIHelper helper = new WMIHelper("root\\standardcimv2\\embedded");
            UnifiedWriteFilter unifiedWriteFilter = helper.QueryFirstOrDefault<UnifiedWriteFilter>(); // The query is correct
            if (unifiedWriteFilter.IsEnabled)
            {
                Console.WriteLine("Write filter Enabled");
                ViewBag.WriteFilterStatus = "enabled";
            }
            else
            {
                Console.WriteLine("Write filter Not Enabled");
                ViewBag.WriteFilterStatus = "disabled";
            }
        }
