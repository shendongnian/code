    class Program
    {
        static void Main()
        {
            // returns an implementation of NameValueCollection
            // which in fact is HttpValueCollection
            var values = HttpUtility.ParseQueryString(string.Empty);
            values["param1"] = "v&=+alue1";
            values["param2"] = "value2";*
 
            // prints "param1=v%26%3d%2balue1&param2=value2"
            Console.WriteLine(values.ToString());
        }
    }
