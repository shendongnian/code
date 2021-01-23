    static void Main(string[] args)
    {
        CustAction a = new CustAction(1);
        CustAction b = new CustAction(2);
        CustAction c = new CustAction(3);
        CustActionCollection coll = new CustActionCollection();
        CustActionCollection coll2 = new CustActionCollection();
    
        coll.Actions.Add(a);
        coll.Actions.Add(b);
        coll.Actions.Add(coll2);
        coll2.Actions.Add(a);
        coll2.Actions.Add(c);
    
        Console.WriteLine("Without distinct");
        coll.Execute();
    
        Console.WriteLine("With distinct");
        Console.WriteLine("Has duplicates: {0}", coll.HasDuplicates());
        coll.ExecuteDistinct();
    
        coll2.Actions.Remove(a);
        Console.WriteLine("Duplicate removed, simple Execute");
        Console.WriteLine("Has duplicates: {0}", coll.HasDuplicates());
        coll.Execute();
    }
