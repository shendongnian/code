    class K
    {
        public int value {get;set;}
        
    }
    class X : K
    { 
        public string Name { get; set; }
    }
    class Y : K
    { 
        public decimal money { get; set; }
    }
    
    void Main()
    {
        List<K> elements = new List<K>();
        elements.Add(new X { Name = "Steve" });
        elements.Add(new Y {money = 100});
        
        // This cannot work, the second element is a Y and doesn't have a Name property
        // foreach(X obj in elements)
        //     Console.WriteLine(obj.Name);
        // This works because only elements of type X are retrieved by the enumeration
        foreach(X obj in elements.OfType<X>())
           Console.WriteLine(obj.Name);
    }
    
