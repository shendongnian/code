    public class WhatIsThis {
    
      private List<IPAddress> ipAddresses = new List<IPAddress>();
    
      public string Name { get; set; }
      public string ConnectionName { get; set; }
      public bool DHCPEnabled { get; set; }
      public List<IPAddress> IPAddresses { get  return ipAddresses; }
    }
