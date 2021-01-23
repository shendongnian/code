    RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);  
    if (processor_name != null)
    {
      if (processor_name.GetValue("ProcessorNameString") != null)
      {
        string value = processor_name.GetValue("ProcessorNameString");
        string freq = value.Split('@')[1];
        ...
      }
    }
