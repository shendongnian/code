    public static string GetMBSN()
    {
       //Getting list of motherboards
       ManagementObjectCollection mbCol = new ManagementClass("Win32_BaseBoard").GetInstances();
       //Enumerating the list
       ManagementObjectCollection.ManagementObjectEnumerator mbEnum = mbCol.GetEnumerator();
       //Move the cursor to the first element of the list (and most probably the only one)
       mbEnum.MoveNext();
       //Getting the serial number of that specific motherboard
       return ((ManagementObject)(mbEnum.Current)).Properties["SerialNumber"].Value.ToString();
    }
