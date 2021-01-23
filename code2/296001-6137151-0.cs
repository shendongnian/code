    using System.Management;
    
        ManagementObjectSearcher MyWMIQuery = new ManagementObjectSearcher("SELECT * FROM Win32_Product") ;
        ManagementObjectCollection MyWMIQueryCollection = MyWMIQuery.Get();
        foreach(ManagementObject MyMO in MyWMIQueryCollection) 
        {
           if(MyMO["Name"].ToString()=="ABC")
        	Console.WriteLine("InstallLocation : " + (MyMO["InstallLocation"] == null ? " " : MyMO["InstallLocation"].ToString()));
    
        	Console.ReadLine();
        }
        MyWMIQueryCollection = null;
        MyWMIQuery = null;
