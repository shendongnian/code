            List<ulong> numbers1 = new List<ulong> { 1, 2, 3, 4, 5, 6 };
            List<ulong> numbers2 = new List<ulong> { 2, 3, 4, 5, 6, 7 };
            List<ulong> numbers3 = new List<ulong> { 3, 4, 5, 6, 7, 8 };
            List<ulong> numbers4 = new List<ulong> { 1, 2, 3, 4, 5, 6 };
            List<List<ulong>> TestList = new List<List<ulong>>();
            TestList.Add(numbers1);
            TestList.Add(numbers2);
            TestList.Add(numbers3);
            TestList.Add(numbers4);
            var result = TestList.GroupBy(x => String.Join(",", x))
                                     .Select(x => x.First().ToList())
                                     .ToList();
