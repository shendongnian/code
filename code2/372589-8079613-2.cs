    //S.M.A.R.T.  Temperature attribute
    const byte TEMPERATURE_ATTRIBUTE = 194;
    public List<byte> GetDriveTemp()
    {
        var retval = new List<byte>();
        try
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");
            //loop through all the hard disks
            foreach (ManagementObject queryObj in searcher.Get())
            {
                byte[] arrVendorSpecific = (byte[])queryObj.GetPropertyValue("VendorSpecific");
                //Find the temperature attribute
                int tempIndex = Array.IndexOf(arrVendorSpecific, TEMPERATURE_ATTRIBUTE);
                retval.Add(arrVendorSpecific[tempIndex + 5]);
            }
        }
        catch (ManagementException err)
        {
            Console.WriteLine("An error occurred while querying for WMI data: " + err.Message);
        }
        return retval;
    }
