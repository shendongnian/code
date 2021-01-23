    //DisplayInfoWMIProvider (c) 2009 by Roger Zander
    
    using System;
    using System.Collections;
    using System.Management.Instrumentation;
    using System.DirectoryServices;
    using System.Management;
    //using System.Security.Principal;
    using Microsoft.Win32;
    using System.Text;
    
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;            
    
    [assembly: WmiConfiguration(@"root\cimv2", HostingModel = ManagementHostingModel.LocalSystem)]
    namespace DisplayInfoWMIProvider
    {
        [System.ComponentModel.RunInstaller(true)]
        public class MyInstall : DefaultManagementInstaller
        {
            public override void Install(IDictionary stateSaver)
            {
                base.Install(stateSaver);
                System.Runtime.InteropServices.RegistrationServices RS = new System.Runtime.InteropServices.RegistrationServices();
    
                //This should be fixed with .NET 3.5 SP1
                //RS.RegisterAssembly(System.Reflection.Assembly.LoadFile(Environment.ExpandEnvironmentVariables(@"%PROGRAMFILES%\Reference Assemblies\Microsoft\Framework\v3.5\System.Management.Instrumentation.dll")), System.Runtime.InteropServices.AssemblyRegistrationFlags.SetCodeBase);
            }
    
            public override void Uninstall(IDictionary savedState)
            {
    
                try
                {
                    ManagementClass MC = new ManagementClass(@"root\cimv2:Win32_MonitorDetails");
                    MC.Delete();
                }
                catch { }
    
                try
                {
                    base.Uninstall(savedState);
                }
                catch { }
            }
        }
    
        [ManagementEntity(Name = "Win32_MonitorDetails")]
        public class DisplayDetails
        {
            [ManagementKey]
            public string PnPID { get; set; }
    
            [ManagementProbe]
            public string SerialNumber { get; set; }
    
            [ManagementProbe]
            public string Model { get; set; }
    
            [ManagementProbe]
            public string MonitorID { get; set; }
    
            /// <summary>
            /// The Constructor to create a new instances of the DisplayDetails class...
            /// </summary>
            public DisplayDetails(string sPnPID, string sSerialNumber, string sModel, string sMonitorID)
            {
                PnPID = sPnPID;
                SerialNumber = sSerialNumber;
                Model = sModel;
                MonitorID = sMonitorID;
            }
    
            /// <summary>
            /// This Function returns all Monitor Details
            /// </summary>
            /// <returns></returns>
            [ManagementEnumerator]
            static public IEnumerable GetMonitorDetails()
            {
                //Open the Display Reg-Key
                RegistryKey Display = Registry.LocalMachine;
                Boolean bFailed = false;
                try
                {
                    Display = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\DISPLAY");
                }
                catch
                {
                    bFailed = true;
                }
    
                if (!bFailed & (Display != null))
                {
    
                    //Get all MonitorIDss
                    foreach (string sMonitorID in Display.GetSubKeyNames())
                    {
                        RegistryKey MonitorID = Display.OpenSubKey(sMonitorID);
    
                        if (MonitorID != null)
                        {
                            //Get all Plug&Play ID's
                            foreach (string sPNPID in MonitorID.GetSubKeyNames())
                            {
                                RegistryKey PnPID = MonitorID.OpenSubKey(sPNPID);
                                if (PnPID != null)
                                {
                                    string[] sSubkeys = PnPID.GetSubKeyNames();
    
                                    //Check if Monitor is active
                                    if (sSubkeys.Contains("Control"))
                                    {
                                        if (sSubkeys.Contains("Device Parameters"))
                                        {
                                            RegistryKey DevParam = PnPID.OpenSubKey("Device Parameters");
                                            string sSerial = "";
                                            string sModel = "";
    
                                            //Define Search Keys
                                            string sSerFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xff });
                                            string sModFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xfc });
    
                                            //Get the EDID code
                                            byte[] bObj = DevParam.GetValue("EDID", null) as byte[];
                                            if (bObj != null)
                                            {
                                                //Get the 4 Vesa descriptor blocks
                                                string[] sDescriptor = new string[4];
                                                sDescriptor[0] = Encoding.Default.GetString(bObj, 0x36, 18);
                                                sDescriptor[1] = Encoding.Default.GetString(bObj, 0x48, 18);
                                                sDescriptor[2] = Encoding.Default.GetString(bObj, 0x5A, 18);
                                                sDescriptor[3] = Encoding.Default.GetString(bObj, 0x6C, 18);
    
                                                //Search the Keys
                                                foreach (string sDesc in sDescriptor)
                                                {
                                                    if (sDesc.Contains(sSerFind))
                                                    {
                                                        sSerial = sDesc.Substring(4).Replace("\0", "").Trim();
                                                    }
                                                    if (sDesc.Contains(sModFind))
                                                    {
                                                        sModel = sDesc.Substring(4).Replace("\0", "").Trim();
                                                    }
                                                }
    
    
                                            }
                                            if (!string.IsNullOrEmpty(sPNPID + sSerFind + sModel + sMonitorID))
                                            {
                                                yield return new DisplayDetails(sPNPID, sSerial, sModel, sMonitorID);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
