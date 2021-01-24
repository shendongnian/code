    public partial class Form1 : Form
    {
        private IntPtr unRegPowerNotify = IntPtr.Zero;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            var settingGuid = new NativeMethods.PowerSettingGuid();
            Guid powerGuid = IsWindows8Plus()
                           ? settingGuid.ConsoleDisplayState : settingGuid.MonitorPowerGuid;
            unRegPowerNotify = NativeMethods.RegisterPowerSettingNotification(
                this.Handle, powerGuid, NativeMethods.DEVICE_NOTIFY_WINDOW_HANDLE);
        }
        private bool IsWindows8Plus()
        {
            var version = Environment.OSVersion.Version;
            if (version.Major > 6) return true;
            if (version.Major == 6 && version.Minor > 1) return true;
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg) {
                case NativeMethods.WM_POWERBROADCAST:
                    if (m.WParam == (IntPtr)NativeMethods.PBT_POWERSETTINGCHANGE)
                    {
                        var settings = (NativeMethods.POWERBROADCAST_SETTING)m.GetLParam(
                            typeof(NativeMethods.POWERBROADCAST_SETTING));
                        switch (settings.Data) {
                            case 0:
                                Console.WriteLine("Monitor Power Off");
                                break;
                            case 1:
                                Console.WriteLine("Monitor Power On");
                                break;
                            case 2:
                                Console.WriteLine("Monitor Dimmed");
                                break;
                        }
                    }
                    m.Result = (IntPtr)1;
                    break;
            }
            base.WndProc(ref m);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.UnregisterPowerSettingNotification(unRegPowerNotify);
        }
    }
