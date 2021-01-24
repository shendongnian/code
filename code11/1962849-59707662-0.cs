     var list = new List<int>();
            list.Add(5);
            list.Add(5);
            list.Add(27);
            list.Add(4);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            list.Add(29);
            list.Add(3);
            list.Add(5);
            list.Add(4);
           var TheMostoccurring =  list.GroupBy(n => n).OrderByDescending(m => m.Count()).Select(m => m.Key).ToList().Take(3);
            foreach (var item in TheMostoccurring)
            {
                Console.WriteLine(item);
            }
