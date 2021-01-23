            ManagementObjectSearcher adapterSearch = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapter");
            foreach (ManagementObject networkAdapter in adapterSearch.Get())
            {
                string pnpDeviceId = (string)networkAdapter["PNPDeviceID"];
                Console.WriteLine("Description  : {0}", networkAdapter["Description"]);
                Console.WriteLine(" PNPDeviceID : {0}", pnpDeviceId);
                if (string.IsNullOrEmpty(pnpDeviceId))
                    continue;
                // make sure you escape the device string
                string txt = "SELECT * FROM win32_PNPEntity where DeviceID='" + pnpDeviceId.Replace("\\", "\\\\") + "'";
                ManagementObjectSearcher deviceSearch = new ManagementObjectSearcher("root\\CIMV2", txt);
                foreach (ManagementObject device in deviceSearch.Get())
                {
                    string[] hardwareIds = (string[])device["HardWareID"];
                    if ((hardwareIds != null) && (hardwareIds.Length > 0))
                    {
                        Console.WriteLine(" HardWareID: {0}", hardwareIds[0]);
                    }
                }
            }
