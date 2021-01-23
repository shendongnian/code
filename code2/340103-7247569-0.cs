    using System;
    using System.Web;
    class Program
    {
        static void Main()
        {
            string value = "http://url.com/index?foo=[01234]&bar=1";
            var uriBuilder = new UriBuilder(value);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["foo"] = query["foo"].Replace("[", "").Replace("]", "");
            uriBuilder.Query = query.ToString();
            value = uriBuilder.ToString();
    
            Console.WriteLine(value);
        }
    }
