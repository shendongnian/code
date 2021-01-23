    List<int> list = new List<int>();
    
    list.Add(1); // No boxing now, since it's using generics!
    list.Add(2);   
    list.Add(3);
    foreach(int value in list) // This is now typesafe, and doesn't cause an unboxing operation
    {
        Console.WriteLine(value);
    }
