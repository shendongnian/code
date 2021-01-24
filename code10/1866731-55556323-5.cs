    public void Print<T>(List<T> source) where T : IHasName
    {
        foreach (var item in source)
        {
            Console.WriteLine("{0}", item.Name);
        }
    }
