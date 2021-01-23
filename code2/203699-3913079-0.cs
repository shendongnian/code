    using System.Management;
    // ...
    
    var query = "select * from WmiMonitorBasicDisplayParams";
    using(var wmiSearcher = new ManagementObjectSearcher("\\root\\wmi", query))
    {
        var results = wmiSearcher.Get();
        foreach (ManagementObject wmiObj in results)
        {
            // get the "Active" property and cast to a boolean, which should 
            // tell us if the display is active. I've interpreted this to mean "on"
            var active = (Boolean)wmiObj["Active"];
        }
    }
