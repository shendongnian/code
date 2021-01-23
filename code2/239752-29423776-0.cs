    using Microsoft.VisualBasic.Devices;
        
              public void getSystemDetails()
                {
                    UserName.Text = Environment.UserName; // User name of PC
                    LabelOS.Text = getOSInfo(); // OS version of pc
                    MachineTxt.Text = Environment.MachineName;// Machine name
                    string OStype = "";
                    if (Environment.Is64BitOperatingSystem) { OStype = "64-Bit, "; } else { OStype = "32-Bit, "; }
                    OStype += Environment.ProcessorCount.ToString() + " Processor";
                    label8.Text = OStype; // Processor type
        
                    ulong toalRam = cinfo.TotalPhysicalMemory;
                    double toal = Convert.ToDouble(toalRam / (1024 * 1024));
                    int t = Convert.ToInt32(Math.Ceiling(toal / 1024).ToString());
                    label6.Text = t.ToString() + " GB";// ram detail
                }
    
            public string getOSInfo()
            {
                //Get Operating system information.
                OperatingSystem os = Environment.OSVersion;
                //Get version information about the os.
                Version vs = os.Version;
    
                //Variable to hold our return value
                string operatingSystem = "";
    
                if (os.Platform == PlatformID.Win32Windows)
                {
                    //This is a pre-NT version of Windows
                    switch (vs.Minor)
                    {
                        case 0:
                            operatingSystem = "95";
                            break;
                        case 10:
                            if (vs.Revision.ToString() == "2222A")
                                operatingSystem = "98SE";
                            else
                                operatingSystem = "98";
                            break;
                        case 90:
                            operatingSystem = "Me";
                            break;
                        default:
                            break;
                    }
                }
                else if (os.Platform == PlatformID.Win32NT)
                {
                    switch (vs.Major)
                    {
                        case 3:
                            operatingSystem = "NT 3.51";
                            break;
                        case 4:
                            operatingSystem = "NT 4.0";
                            break;
                        case 5:
                            if (vs.Minor == 0)
                                operatingSystem = "Windows 2000";
                            else
                                operatingSystem = "Windows XP";
                            break;
                        case 6:
                            if (vs.Minor == 0)
                                operatingSystem = "Windows Vista";
                            else
                                operatingSystem = "Windows 7 or Above";
                            break;
                        default:
                            break;
                    }
