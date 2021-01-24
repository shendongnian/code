    private class Foo
    {
        public int Item1;
        public int Item2;
        public int Item3;
    }
     
    static void Main(string[] args)
    {
        List<Foo> foos = new List<Foo> 
                               { 
                                   new Foo() { Item1 = 1, Item2 = 2, Item3 = 3 },
                                   new Foo() { Item1 = 4, Item2 = 5, Item3 = 6 },
                                   new Foo() { Item1 = 7, Item2 = 8, Item3 = 9 }
                               };
     
        // Create a list of lists where each list has three elements corresponding to 
        // the values stored in Item1, Item2, and Item3.  Then use SelectMany
        // to flatten the list of lists.
        var items = foos.Select(f => new List<int>() { f.Item1, f.Item2, f.Item3 }).SelectMany(item => item).Distinct();
     
        foreach (int item in items)
            Console.WriteLine(item.ToString());
         
        Console.ReadLine();
    }
