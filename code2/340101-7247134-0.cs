    class Program
    {
        static void Main()
        {
            var resp = XElement.Load("test.xml");
            var statusCode = resp
                .Descendants("{http://integration.fiapi.com}StatusCode")
                .FirstOrDefault();
            if (statusCode != null)
            {
                Console.WriteLine(statusCode.Value);
            }
        }
    }
