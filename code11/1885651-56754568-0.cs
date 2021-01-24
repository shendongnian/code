    try
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Volume");
        foreach (ManagementObject queryObj in searcher.Get())
        {
            Console.WriteLine("DriveLetter: {0}", queryObj["DriveLetter"]);
            Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
            if (queryObj["Capacity"] != null)
            {
                string sQuery = "Win32_EncryptableVolume.DeviceID='" + queryObj["DeviceID"] + "'";
                ManagementObject classInstance = new ManagementObject("root\\CIMV2\\Security\\MicrosoftVolumeEncryption", sQuery, null);
    
                ManagementBaseObject outParams = classInstance.InvokeMethod("GetEncryptionMethod", null, null);
                Console.WriteLine("Out parameters =>");
                Console.WriteLine("EncryptionMethod: " + outParams["EncryptionMethod"]);
                Console.WriteLine("EncryptionMethodFlags: " + outParams["EncryptionMethodFlags"]);
                Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
                Console.WriteLine("SelfEncryptionDriveEncryptionMethod: " + outParams["SelfEncryptionDriveEncryptionMethod"]);
            }                      
        }
    }
    catch (ManagementException me)
    {
        System.Windows.Forms.MessageBox.Show("An error occurred while querying for WMI data: " + me.Message);
    }
