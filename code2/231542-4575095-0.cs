    namespace TestHarnessHardDrives
{
    class Program
    {
        public static Dictionary<string, HardDrive> deviceCollection = new Dictionary<string, HardDrive>
        static void getHardDrives()
        {
            string keyHDDName;
            try
            {
                ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_LogicalDisk");
                deviceCollection.Add("Western Digital", new HardDrive("Western Digital",100000));
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["Description"].Equals("Local Fixed Disk"))
                    {
                        Console.WriteLine("Description: {0}", queryObj["Description"]);
                        keyHDDName = queryObj["VolumeName"].ToString() + " "
                                    + queryObj["Caption"].ToString();
                        deviceCollection.Add(keyHDDName, new HardDrive(keyHDDName, 100000));
                    };
                    //     Console.WriteLine("FileSystem: {0}", queryObj["FileSystem"]);
                    //     Console.WriteLine("FreeSpace: {0}", queryObj["FreeSpace"]);
                    //     Console.WriteLine("Size: {0}", queryObj["Size"]);
                    //     Console.WriteLine("VolumeSerialNumber: {0}", queryObj["VolumeSerialNumber"]);
                }
            }
        //      deviceCollection.Add(new SystemInterface("Western Digital"));
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Create an Array type Collection of DeviceInfo " +
                                    "objects and use it");
            getHardDrives();
            foreach (DeviceInfo myDevices in deviceCollection)
            {
                myDevices.Named();
                myDevices.GetType();
            }
            deviceCollection["Western Digital"].Named();
            Console.ReadKey();
        }
    }
