    static void Main(string[] args)
    { 
        Whatever one = new Whatever() {GroupId = 1, Id = 1, Value = 2};
        Whatever two = new Whatever() { GroupId = 1, Id = 2, Value = 8 };
        Whatever three = new Whatever() { GroupId = 2, Id = 3, Value = 16 };
        Whatever four = new Whatever() { GroupId = 2, Id = 4, Value = 7 };
        Whatever five = new Whatever() { GroupId = 3, Id = 5, Value = 21 };
        Whatever six = new Whatever() { GroupId = 3, Id = 6, Value = 12 };
        Whatever seven = new Whatever() { GroupId = 4, Id = 7, Value = 5 };
        Whatever eight = new Whatever() { GroupId = 5, Id = 8, Value = 17 };
        Whatever nine = new Whatever() { GroupId = 6, Id = 9, Value = 13 };
        Whatever ten = new Whatever() { GroupId = 7, Id = 10, Value = 44 };
    
        List<Whatever> list = new List<Whatever>();
        list.Add(one);
        list.Add(two);
        list.Add(three);
        list.Add(four);
        list.Add(five);
        list.Add(six);
        list.Add(seven);
        list.Add(eight);
        list.Add(nine);
        list.Add(ten);
        
        var results = (from w in list
                       group w by w.GroupId into g
                       select new { GroupId = g.Key,
                                    Value = g.Max(w => w.Value),
                                    Id = g.OrderBy(w=>w.Value).Last().Id }).
                       OrderByDescending(w=>w.Value).Take(5);
        foreach (var r in results)
        {
            Console.WriteLine("GroupId = {0},
                               Id = {1},
                               Value = {2}",
                               r.GroupId, r.Id,  r.Value);
        }
    
    }
