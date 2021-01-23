        private bool SetAllowHybridSleep(bool enabled)
        {
            //Machine to work on, "." for local
            string RemotePC = ".";
            //Set the namespace to the power namespace, used throughout the function
            ManagementScope ms = new ManagementScope(@"\\" + RemotePC + @"\root\cimv2\power");
            //Will hold each of our queries
            ObjectQuery oq = null;
            //Will hold the values of our power plan and the specific setting that we want to change
            Guid PowerPlanInstanceId = Guid.Empty;
            string PowerSettingInstanceId = null;
            //Look for the specific setting that we want
            oq = new ObjectQuery(string.Format("SELECT * FROM Win32_PowerSetting WHERE ElementName = 'Allow hybrid sleep'"));
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(ms, oq))
            {
                ManagementObjectCollection results = mos.Get();
                foreach (ManagementObject obj in results)
                {
                    foreach (PropertyData p in obj.Properties)
                    {
                        if (p.Name == "InstanceID")
                        {
                            //This will give us a string with a GUID specific to our setting
                            PowerSettingInstanceId = p.Value.ToString();
                            break;
                        }
                    }
                }
            }
            //Sanity check
            if (string.IsNullOrEmpty(PowerSettingInstanceId))
            {
                Console.WriteLine("System does not support hybrid sleep");
                return false;
            }
            //Look for the active power scheme
            oq = new ObjectQuery("SELECT * FROM Win32_PowerPlan WHERE IsActive=True");
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(ms, oq))
            {
                ManagementObjectCollection results = mos.Get();
                foreach (ManagementObject obj in results)
                {
                    foreach (PropertyData p in obj.Properties)
                    {
                        if (p.Name == "InstanceID")
                        {
                            //The instance contains a string with a GUID inside of it, use the code below to get the GUID by itself
                            if (!Guid.TryParse(System.Text.RegularExpressions.Regex.Match(p.Value.ToString(), @"\{[0-9a-f]{8}\-[0-9a-f]{4}\-[0-9a-f]{4}\-[0-9a-f]{4}\-[0-9a-f]{12}\}").Value, out PowerPlanInstanceId))
                            {
                                Console.WriteLine("Could not find active power plan");
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            //Now we need to update the actual power setting in the active plan
            //Get all power schemes for the target setting
            oq = new ObjectQuery(string.Format("ASSOCIATORS OF {{Win32_PowerSetting.InstanceID=\"{0}\"}} WHERE ResultClass = Win32_PowerSettingDataIndex", PowerSettingInstanceId.Replace(@"\", @"\\")));
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(ms, oq))
            {
                ManagementObjectCollection results = mos.Get();
                foreach (ManagementObject obj in results)
                {
                    foreach (PropertyData p in obj.Properties)
                    {
                        //See if the current scheme is the current setting. This will happen twice, once for AC and once for DC
                        if (p.Name == "InstanceID" && p.Value.ToString().Contains(PowerPlanInstanceId.ToString()))
                        {
                            //Change the value of the current setting
                            obj.SetPropertyValue("SettingIndexValue", (enabled ? "1" : "0"));
                            obj.Put();
                            break;
                        }
                    }
                }
            }
            return true;
        }
