    using System;
    using System.Web;
    
    class Program
    {
        static void Main()
        {
            var uri = new Uri("http://foo.com/?param1=value1&param2=value2");
            var values = HttpUtility.ParseQueryString(uri.Query);
            foreach (string key in values.Keys)
            {
                Console.WriteLine("key: {0}, value: {1}", key, values[key]);
            }
        }
    }
