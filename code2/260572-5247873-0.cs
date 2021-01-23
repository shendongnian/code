    using System.Management
    SelectQuery query = new SelectQuery("Win32_UserAccount");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    foreach (ManagementObject envVar in searcher.Get())
    {
         Console.WriteLine("Username : {0}", envVar["Name"]);
    }
               
