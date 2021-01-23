    using Microsoft.WindowsAPICodePack.ApplicationServices;
    // . . .
            PowerManager.IsMonitorOnChanged += new EventHandler(MonitorOnChanged);
    // . . .
        void MonitorOnChanged(object sender, EventArgs e)
        {
            settings.MonitorOn = PowerManager.IsMonitorOn;
            AddEventMessage(string.Format("Monitor status changed (new status: {0})", PowerManager.IsMonitorOn ? "On" : "Off"));
        }
