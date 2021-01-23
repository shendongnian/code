       public MainPage()
       {
                InitializeComponent();
                GetDeviceInfo();    
       }    
       public void GetDeviceInfo()
       {
                long ApplicationMemoryUsage = DeviceStatus.ApplicationCurrentMemoryUsage;
                long PeakMemoryUsage = DeviceStatus.ApplicationPeakMemoryUsage;
                string FirmwareVersion = DeviceStatus.DeviceFirmwareVersion;
                string HardwareVersion = DeviceStatus.DeviceHardwareVersion;
                string Manufacturer = DeviceStatus.DeviceManufacturer;
                string DeviceName = DeviceStatus.DeviceName;
                long TotalMemory = DeviceStatus.DeviceTotalMemory;
                string OSVersion = Environment.OSVersion.Version.ToString(); ;
                PowerSource powerSource = DeviceStatus.PowerSource;
                AddToList("Memory Usage :" + ApplicationMemoryUsage);
                AddToList("Peak Memory Usage :" + PeakMemoryUsage);
                AddToList("Firmware Version :" + FirmwareVersion);
                AddToList("Hardware Version :" + HardwareVersion);
                AddToList("Manufacturer :" + Manufacturer);
                AddToList("Total Memory :" + TotalMemory);
                AddToList("Power Source:" + powerSource.ToString());
                AddToList("Operating System: Windows Phone " + OSVersion.ToString());
    
       }    
       public void AddToList(string Property)
       {
                lstboxDeviceInfo.Items.Add(Property);
       }
