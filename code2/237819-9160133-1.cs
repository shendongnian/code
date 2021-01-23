     private ManagementEventWatcher managementEventWatcher;
        private readonly Dictionary<string, string> powerValues = new Dictionary<string, string>
                             {
                                 {"4", "Entering Suspend"},
                                 {"7", "Resume from Suspend"},
                                 {"10", "Power Status Change"},
                                 {"11", "OEM Event"},
                                 {"18", "Resume Automatic"}
                             };
        public void InitPowerEvents()
        {
            var q = new WqlEventQuery();
            var scope = new ManagementScope("root\\CIMV2");
            q.EventClassName = "Win32_PowerManagementEvent";
            managementEventWatcher = new ManagementEventWatcher(scope, q);
            managementEventWatcher.EventArrived += PowerEventArrive;
            managementEventWatcher.Start();
        }
        private void PowerEventArrive(object sender, EventArrivedEventArgs e)
        {
            foreach (PropertyData pd in e.NewEvent.Properties)
            {
                if (pd == null || pd.Value == null) continue;
                var name = powerValues.ContainsKey(pd.Value.ToString())
                               ? powerValues[pd.Value.ToString()]
                               : pd.Value.ToString();
                Console.WriteLine("PowerEvent:"+name);
            }
        }
        public void Stop()
        {
            managementEventWatcher.Stop();
        }
