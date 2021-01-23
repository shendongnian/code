    static void Main(string[] args)
    {
        var aList = (from item in Enumerable.Range(1, 10)
                        select new A { Z1 = item, Z2 = item * 2 }).ToList();
        var bList = (from item in Enumerable.Range(10, 100)
                     select new B { J5 = item, J6 = item / 2 }).ToList();
        var intersect = (from a in aList
                         join b in bList
                            on a.Z2 equals b.J6
                         select new { A = a, B = b }).ToList();
        foreach (var item in intersect)
        {
            Console.WriteLine("A:{{{0}}}, B:{{{1}}}", item.A, item.B);
        }
    }
