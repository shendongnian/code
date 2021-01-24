    class Program
    {
        static void Main(string[] args)
        {
            var wlanClient = new WlanClient();
            foreach (WlanClient.WlanInterface wlanInterface in wlanClient.Interfaces)
            {
                var test = wlanInterface.CurrentConnection.wlanAssociationAttributes.Dot11Bssid;
                Console.WriteLine(test);
            }
            Console.ReadKey();
        }
    }
