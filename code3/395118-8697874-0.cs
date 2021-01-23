      using System.Net.NetworkInformation;
        
        class Program
        {
            static void Main(string[] args)
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
        
                    Console.WriteLine(nic.NetworkInterfaceType);
                    Console.WriteLine(nic.Name);
                }
            }
        }
