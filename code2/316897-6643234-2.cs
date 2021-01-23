            ManagementScope sc =
                new ManagementScope(@"\\YOURCOMPUTERNAME\root\cimv2");
            ObjectQuery query =
                new ObjectQuery("Select * from Win32_USBHub");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(sc, query);
            ManagementObjectCollection result = searcher.Get();
            foreach (ManagementObject obj in result)
            {
                if (obj["Description"] != null) Console.WriteLine("Description:\t" + obj["Description"].ToString());
                if (obj["DeviceID"] != null) Console.WriteLine("DeviceID:\t" + obj["DeviceID"].ToString());
                if (obj["PNPDeviceID"] != null) Console.WriteLine("PNPDeviceID:\t" + obj["PNPDeviceID"].ToString());
            }
