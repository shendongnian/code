    class Program
    {
        static void Main()
        {
            var serializer = new JavaScriptSerializer();
            string json = null;
            using (var client = new WebClient())
            {
                json = client.DownloadString("http://xurrency.com/api/eur/gbp/1.5");
            }
            var response = serializer.Deserialize<XurrencyResponse>(json);
            Console.WriteLine(response.Status);
        }
    }
