    ManagementClass wmiManagementProcessorClass = new ManagementClass("Win32_Processor");
    ManagementObjectCollection wmiProcessorCollection = wmiManagementProcessorClass.GetInstances();
    foreach (ManagementObject wmiProcessorObject in wmiProcessorCollection)
    {
        try
        {
            MessageBox.Show(wmiProcessorObject.Properties["Name"].Value.ToString());
        }
        catch (ManagementException ex)
        {
            // real error handling here
            MessageBox.Show(ex.Message);
        }
    }
