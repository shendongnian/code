    static void Main()
    {
        List<A> listA = new List<A>{
                new A {Number =4},
                new A {Number =1},
                new A {Number =5}
        };
        Work(listA.Select(a => a.Number));
    }
    public static void Work(IEnumerable<int> items)
    {
        foreach (number item in items)
        {
            // do something with number;
        }
    }
