    public void Test()
    {
        var o = new[] {new {Name = "test", Age = 10}, new {Name = "test2", Age = 5}};
        ShowMeAll(o, i => i.Age);
    }
    
    public void ShowMeAll<T>(IEnumerable<T> items, Func<T, object> keySelector)
    {
        items.OrderBy(keySelector)
            .ToList()
            .ForEach(t => Console.WriteLine(t));
    }
