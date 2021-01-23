    using (System.Management.ManagementClass shareObj = new
    System.Management.ManagementClass("Win32_Share"))
    {
      System.Management.ManagementObjectCollection shares =
      shareObj.GetInstances();
    
      foreach (System.Management.ManagementObject share in shares)
      {
        Console.WriteLine("Name: " + share["Name"].ToString());
      }
    }
