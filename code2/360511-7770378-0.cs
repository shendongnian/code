    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    namespace IPValidator
    {
        class Program
        {
            static void Main (string[] args)
            {
                Action<string> TestIP = (ip) => Console.Out.WriteLine (ip + " is valid? " + ip.IsValidIP ());
                TestIP ("99");
                TestIP ("99.99.99.99");
                TestIP ("255.255.255.256");
                TestIP ("abc");
                TestIP ("192.168.1.1");
            }
        }
        internal static class IpExtensions
        {
            public static bool IsValidIP (this string address)
            {
                if (!Regex.IsMatch (address, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b"))
                    return false;
                IPAddress dummy;
                return IPAddress.TryParse (address, out dummy);
            }
        }
    }
