c#
        static void Main(string[] args)
        {
            var client = new LookupClient(new IPEndPoint(IPAddress.Parse("198.101.242.72"),53));
            var result = client.Query("www.nasill.com", QueryType.A);
            foreach (var aRecord in result.Answers.ARecords())
            {
                Console.WriteLine("Correct Result is: "+aRecord.Address);
            }
            
            IPHostEntry hosten = Dns.GetHostEntry("www.nasill.com");
            if (hosten.AddressList.Count() >= 1)
            {
                string ip = hosten.AddressList[0].ToString();
                Console.WriteLine("Your computer dns says: "+ip);
            }
            Console.ReadLine();
        }
