    static void Main(string[] args)
    {
        HttpRequest request = new HttpRequest("", "http://www.stackoverflow.com", "q1=v1&q2=v2,v2&q3=v3&q1=v4");
    
        var queryString = request.QueryString;
    
        foreach (string k in queryString.Keys)
        {
            Console.WriteLine(k);
            int times = queryString.GetValues(k).Length;
            if (times > 1)
            {
                Console.WriteLine("Key {0} appears {1} times.", k, times);
            }
        }
    
        Console.ReadLine();
    }
