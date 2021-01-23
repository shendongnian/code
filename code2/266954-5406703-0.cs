            Dictionary<int, string> dic1 = new Dictionary<int,string>();
            Dictionary<string, decimal> dic2 = new Dictionary<string,decimal>();
            dic1.Add(1, "one");
            dic1.Add(2, "two");
            dic1.Add(3, "three");
            dic1.Add(4, "four");
            dic1.Add(5, "five");
            dic2.Add("one",1.0m);
            dic2.Add("two", 2.0m);
            dic2.Add("three", 3.0m);
            dic2.Add("four", 4.0m);
            dic2.Add("five", 5.0m);
            Dictionary<int, decimal> result = (from d1 in dic1
                                               from d2 in dic2
                                               where d1.Value == d2.Key
                                               select new { d1.Key, d2.Value }).ToDictionary(p=>p.Key, p=>p.Value);
