    public void Test()
    {
        var myList = new SortedSet<MyObject>(new MyComparer());
    
        myList.Add(new MyObject { Id = 1, Name = "ZZZ" });
        myList.Add(new MyObject { Id = 2, Name = "NNN" });
        myList.Add(new MyObject { Id = 3, Name = "PPP" });
        myList.Add(new MyObject { Id = 4, Name = "AAA" });
    
        foreach (var obj in myList)
        {
            Console.WriteLine($"{obj.Name} -> {obj.Id}");
        }
    }
    public class MyComparer : IComparer<MyObject>
    {
        public int Compare(MyObject x, MyObject y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
    
    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
