    public class ServicePreshutdownBase : ServiceBase
    {
        public bool Preshutdown { get; private set; }
        public ServicePreshutdownBase()
        {
            Version versionWinVistaSp1 = new Version(6, 0, 6001);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version >= versionWinVistaSp1)
            {
                var acceptedCommandsField = typeof (ServiceBase).GetField("acceptedCommands", BindingFlags.Instance | BindingFlags.NonPublic);
                if (acceptedCommandsField == null)
                    throw new InvalidOperationException("Private field acceptedCommands not found on ServiceBase");
                int acceptedCommands = (int) acceptedCommandsField.GetValue(this);
                acceptedCommands |= 0x00000100; //SERVICE_ACCEPT_PRESHUTDOWN;
                acceptedCommandsField.SetValue(this, acceptedCommands);
            }
        }
        
        protected override void OnCustomCommand(int command)
        {
            // command is SERVICE_CONTROL_PRESHUTDOWN
            if (command == 0x0000000F)
            {
                var baseCallback = typeof(ServiceBase).GetMethod("ServiceCommandCallback", BindingFlags.Instance | BindingFlags.NonPublic);
                if (baseCallback == null)
                    throw new InvalidOperationException("Private method ServiceCommandCallback not found on ServiceBase");
                try
                {
                    Preshutdown = true;
                    //now pretend stop was called 0x00000001
                    baseCallback.Invoke(this, new object[] {0x00000001});
                }
                finally
                {
                    Preshutdown = false;
                }
            }
        }
    }
