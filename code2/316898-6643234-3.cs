            ManagementScope sc =
                new ManagementScope(@"\\YOURCOMPUTERNAME\root\cimv2");
            ObjectQuery query =
                new ObjectQuery("Select * from Win32_SerialPort");
            searcher = new ManagementObjectSearcher(sc, query);
            result = searcher.Get();
            foreach (ManagementObject obj in result)
            {
                if (obj["Caption"] != null) Console.WriteLine("Caption:\t" + obj["Description"].ToString());
                if (obj["Description"] != null) Console.WriteLine("Description:\t" + obj["DeviceID"].ToString());
                if (obj["DeviceID"] != null) Console.WriteLine("DeviceID:\t" + obj["PNPDeviceID"].ToString());
            }
