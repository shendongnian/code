     static void Main(string[] args)
     {
        ManagementObjectSearcher usersSearcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_UserAccount");
        ManagementObjectCollection users = usersSearcher.Get();
    
        var localUsers = users.Cast<ManagementObject>().Where(
            u => (bool)u["Disabled"] == false;
    
        foreach (ManagementObject user in localUsers)
        {
            Console.WriteLine("Account Type: " + user["AccountType"].ToString());               
            Console.WriteLine("Full Name: " + user["FullName"].ToString());
            Console.WriteLine("SID: " + user["SID"].ToString());
            Console.WriteLine("SID Type: " + user["SIDType"].ToString());
            Console.WriteLine("Status: " + user["Status"].ToString());
                Console.WriteLine("Disabled: " + user["Disabled"].ToString());
            Console.WriteLine("Domain: " + user["Domain"].ToString());
        }
     }
     
