    Random randNum = new Random();
    
    int password = 432678;
    int valt = 999999;
    
    //INITIALIZE LIST
    List<int> list = new List<int>();
    for (int i = 0; i < valt; i++) list.Add(i);
    
    
    while (list.Count > 0)
    {
        int index = randNum.Next(1, list.Count);
        Console.WriteLine("CURRENT: " + list[index] + ", LIST SIZE: " + list.Count);
    
        //BREAK WHILE
        if (list[index] == password) break;
    
        //REMOVE INDEX FROM LIST
        list.RemoveAt(index);
    }
    
    Console.WriteLine("password: " + password);
    Console.ReadLine();
