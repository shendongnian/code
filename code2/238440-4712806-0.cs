            IEnumerable<IGrouping<char, string>> queryFoodGroups =from item in groupingQuery 
                                                                  group item by item[0];
            foreach (IGrouping<char, string> i in queryFoodGroups)
            {
                Console.WriteLine(i.Key);
                foreach (string item in i)
                {
                    Console.WriteLine(item);
                }
            }
