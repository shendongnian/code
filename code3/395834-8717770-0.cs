    public void PrintTypes(IEnumerable items) 
    { 
        foreach(var item in items) 
            Console.WriteLine(item.GetType().FullName); 
    }
