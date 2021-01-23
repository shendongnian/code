            var mySet = new Dictionary<string, int>();
            mySet.Add("AA", 12);
            mySet.Add("AAA", 32);
            mySet.Add("AAB", 4);
            mySet.Add("AABB", 38);
            mySet.Add("BBAA", 3);
            mySet.Add("CDDDA", 76);
            //...
            mySet.Add("YZZZ", 45);
            mySet.Add("ZZZZZY", 356);
            var results = SearchAndSortBy(mySet, "AA");
            foreach (var item in results)
            {
                Console.Write(item.Key);
                Console.Write(" ");
                Console.WriteLine(item.Value);
            }
