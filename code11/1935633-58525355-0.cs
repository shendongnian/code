    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication137
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> ipAddresses = new List<string>() {
                    "172.15.15.1",
                    "172.15.15.2",
                    "172.15.15.3",
                    "172.15.15.4",
                    "172.16.15.1",
                    "172.17.15.1"
                };
                MatchIp matchIP = new MatchIp("172.15", "172.16");
                List<string> results = ipAddresses.Where(x => matchIP.Equals(x)).ToList();
            }
        }
        public class MatchIp : IEquatable<string>
        {
            int[] startAddress { get; set; }
            int[] endAddress { get; set; }
            int length { get; set; }
            public MatchIp(string startAddressStr, string endAddressStr)
            {
                startAddress = startAddressStr.Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
                endAddress = endAddressStr.Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
                length = Math.Min(startAddress.Count(), endAddress.Count());
            }
            public Boolean Equals(string ip)
            {
                Boolean results = true;
                try
                {
                    int[] address = ip.Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
                    if (address.Length == 4)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if ((address[i] < startAddress[i]) || (address[i] > endAddress[i]))
                            {
                                results = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        results = false;
                    }
                }
                catch (Exception ex)
                {
                    results = false;
                }
                return results;
            }
        }
     
    }
