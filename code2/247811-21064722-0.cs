    var parallelPort = new ManagementObjectSearcher("Select * From Win32_ParallelPort");
    //Dump(parallelPort.Get());
    foreach (var rec in parallelPort.Get())
    {     
        var wql = "Select * From Win32_PnPAllocatedResource";
        var pnp = new ManagementObjectSearcher(wql);
    
        var searchTerm = rec.Properties["PNPDeviceId"].Value.ToString();
        // compensate for escaping
        searchTerm = searchTerm.Replace(@"\", @"\\");
    
        foreach (var pnpRec in pnp.Get())
        {
            var objRef = pnpRec.Properties["dependent"].Value.ToString();
            var antref = pnpRec.Properties["antecedent"].Value.ToString();	
    
            if (objRef.Contains(searchTerm))
            {
                var wqlPort = "Select * From Win32_PortResource";
                var port = new ManagementObjectSearcher(wqlPort);
                foreach (var portRec in port.Get())
                {
                    if (portRec.ToString() == antref)
                    { 
                        Console.WriteLine( "{0} [{1};{2}]",
                            rec.Properties["Name"].Value,
                            portRec.Properties["StartingAddress"].Value, 
                            portRec.Properties["EndingAddress"].Value );
                    }
                }
            }
        }
    }
