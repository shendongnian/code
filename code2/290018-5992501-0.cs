    ManagementObjectSearcher searcher 
         = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
        
        string graphicsCard = string.Empty;
        foreach (ManagementObject share in searcher.Get())
        {
            foreach (PropertyData property in share.Properties)
            {
               if (property.Name == "Description")
               {
                   graphicsCard = property.Value.ToString();
               }
            }
        }
