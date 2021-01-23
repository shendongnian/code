      foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
      {
        Console.WriteLine("Name: " + netInterface.Name);
        Console.WriteLine("Description: " + netInterface.Description);
        Console.WriteLine("Addresses: ");
        IPInterfaceProperties ipProps = netInterface.GetIPProperties();
        foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
        {
          Console.WriteLine(" " + addr.Address.ToString());
        }
        Console.WriteLine("");
      }
