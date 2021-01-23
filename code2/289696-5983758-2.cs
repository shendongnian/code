    using System.Collections.Generic;
    using System.Linq;
    
    namespace LINQDictionaryDemo
    {
        public class IPAddress
        {
            public int Index { get; private set; }
            public string Value { get; private set; }
    
            public IPAddress(int Index, string Value)
            {
                this.Index = Index;
                this.Value = Value;
            }
        }
    
        public class NetworkConnection
        {
            public string Name { get; set; }
            public string ConnectionName { get; set; }
            public bool DHCPEnabled { get; set; }
            public List<IPAddress> IPAddresses { get; set; }
    
            public Dictionary<string, object> ToDictionary()
            {
                return new Dictionary<string, object>
                           {
                                { "ConnectionName", ConnectionName }
                                , { "DHCPEnabled", DHCPEnabled.ToString() }
                                , {"IPAddresses", IPAddresses.ToDictionary(k => k.Index, v => v.Value)}
                           };
            }
        }
    
        public static class Demo
        {
            public static void Run()
            {
                var lnc = new List<NetworkConnection>
                              {
                                  new NetworkConnection
                                      {
                                          Name = "Broadcom",
                                          ConnectionName = "Local Area Connection",
                                          DHCPEnabled = false,
                                          IPAddresses = new List<IPAddress> {new IPAddress(1, "abc.de.fg.h")}
                                      }
                              };
                var dic = lnc.ToDictionary(k => k.Name, v => v.ToDictionary());
            }
        }
    }
