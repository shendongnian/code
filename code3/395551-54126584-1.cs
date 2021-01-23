    Try This:
          using System;
    using System.Net;
    namespace GetLocalIP
    {
    class Program
    {
    static void Main(string[] args)
    {
    string host = Dns.GetHostName();
    string AddressIP6 = string.Empty;
     IPAddress[] IPAdd = Dns.GetHostAddresses(host);
    foreach (IPAddress ip6 in IPAdd){
    AddressIP6 = ip6.ToString();
    }
    Console.WriteLine("Local system IP Address : " + AddressIP6);
     Console.ReadKey();
    }
    }
}
