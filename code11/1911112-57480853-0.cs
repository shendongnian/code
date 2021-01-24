    HostInterface int1 = new HostInterface
    {
       type = 2,
       main = 1,
       useip = 1,
       ip = 192.168.1.1,
       dns  = "",
       port = 161
    };
    
    HostInterface int2 = new HostInterface
    {
       type = 1,
       main = 1,
       useip = 1,
       ip = 192.168.1.1,
       dns  = "",
       port = 10050
    };
    
    
    List<HostInterface> HostInterfaces = new List<HostInterface>();
    HostInterfaces.Add(int1);
    HostInterfaces.Add(int2);
    
    string json = JsonConvert.SerializeObject(HostInterfaces, Formatting.Indented);
