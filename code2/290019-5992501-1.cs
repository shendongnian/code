    ManagementObjectSearcher searcher 
         = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
        
        string graphicsCard = string.Empty;
        foreach (ManagementObject mo in searcher.Get())
        {
            foreach (PropertyData property in mo.Properties)
            {
               if (property.Name == "Description")
               {
                   graphicsCard = property.Value.ToString();
               }
            }
        }
