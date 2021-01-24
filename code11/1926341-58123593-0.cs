            string instance = "{112,This is the first day 23/12/2009},{132,This is the second day 24/12/2009}";
            string[] tokens = instance.Replace("},{", "}{").Split('}', '{');
            foreach (string item in tokens)
            {
                if (string.IsNullOrWhiteSpace(item)) continue;
                Console.WriteLine(item);
            }
            Console.ReadLine();
