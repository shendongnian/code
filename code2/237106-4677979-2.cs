            var dict = new NamespaceDictionary<int>();
            dict.Add("ns1.var1", 1);
            dict.Add("ns2.var1", 2);
            dict.Add("ns2.var2", 3);
            Console.WriteLine(dict["var1"]);
            Console.WriteLine(dict["ns2.var1"]);
            Console.WriteLine(dict["var2"]);
            Console.ReadLine();
