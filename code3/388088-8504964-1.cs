    using System;
    using System.Web;
    
    class Program
    {
        static void Main()
        {
            var values = HttpUtility.ParseQueryString(string.Empty);
            values["param1"] = "value1";
            values["param2"] = "value2";
            var builder = new UriBuilder("http://foo.com");
            builder.Query = values.ToString();
            var url = builder.ToString();
            Console.WriteLine(url);
        }
    }
