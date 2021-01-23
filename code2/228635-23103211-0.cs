        static void Main(string[] args)
        {
            ManagementObjectCollection ManObjReturn;
            ManagementObjectSearcher ManObjSearch;
            ManObjSearch = new ManagementObjectSearcher("Select * from **Win32_ParallelPort**");
            ManObjReturn = ManObjSearch.Get();
            foreach (ManagementObject ManObj in ManObjReturn)
            {
                //int s = ManObj.Properties.Count;
                //foreach (PropertyData d in ManObj.Properties)
                //{
                //    MessageBox.Show(d.Name);
                //}
                Console.WriteLine(ManObj["DeviceID"].ToString());
                Console.WriteLine(ManObj["PNPDeviceID"].ToString());
                Console.WriteLine(ManObj["Name"].ToString());
                Console.WriteLine(ManObj["Caption"].ToString());
                Console.WriteLine(ManObj["Description"].ToString());
                Console.WriteLine(ManObj["ProviderType"].ToString());
                Console.WriteLine(ManObj["Status"].ToString());
            }
