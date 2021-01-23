    //import the System.Management namespace at the top in your "using" statement. Then in a method, or on a button click:
    ManagementObjectCollection collection;
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'"))
      collection = searcher.Get();
    foreach (ManagementObject currentObject in collection)
    {
      ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + currentObject["DeviceID"] + "'");
      MessageBox.Show(theSerialNumberObjectQuery["SerialNumber"].ToString());
    }
    collection.Dispose();
