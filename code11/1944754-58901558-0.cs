        string foo = "[[demo.waka=340]]";
        DateTime start;
        for (int y = 0; y < 5; y++)
        {
            start = DateTime.Now;
            for (int x = 0; x < 10000; x++)
            {
                string outputString2 = Regex.Match(foo, @"(?<=\[\[demo\.waka=)\d+(?=\]\])").Value;
            }
            Console.WriteLine("1: {0}", (DateTime.Now - start).TotalMilliseconds);
            start = DateTime.Now;
            for (int x = 0; x < 10000; x++)
            {
                int outputNumber3 = Convert.ToInt32(foo.Replace("[[demo.waka=", "").Replace("]]", ""));
            }
            Console.WriteLine("2: {0}", (DateTime.Now - start).TotalMilliseconds);
        }
        Console.ReadLine();
