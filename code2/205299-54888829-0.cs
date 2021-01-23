        var list = new List<string>();
        list.Add("cat");
        list.Add("dog");
        list.Add("moth");
        if (list.Contains("MOTH", StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("found");
        }
