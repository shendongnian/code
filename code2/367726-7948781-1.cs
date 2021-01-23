    class Program
    {
        static void Main(string[] args)
        {
            var addresses = DnsAddr.GetAddress("google.com");
            foreach (var address in addresses)
                Console.WriteLine(address.ToString());
        }
    }
