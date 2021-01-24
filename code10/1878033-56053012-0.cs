     ServicesSection servicesSection = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
            foreach (ServiceElement service in servicesSection.Services)
            {
                if (service.Name == "SmgService.PrintService")
                {
                    foreach (BaseAddressElement item in service.Host.BaseAddresses)
                    {                       
                        MessageBox.Show(item.BaseAddress.ToString());
                    }
                   
                }
            }
  
        string resultBase = "";
            ServicesSection services = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
            foreach (ServiceElement service in services.Services)
            {
                if (service.Name == whichService)
                {
                    BaseAddressElementCollection baseElement = service.Host.BaseAddresses;
                    foreach (BaseAddressElement item in baseElement)
                    {
                        resultBase = item.BaseAddress;
                    }
                }
            }
            return resultBase;
