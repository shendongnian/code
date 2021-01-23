    List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
    for (int i = 0; i < myList.Count; i++)
    {
        Console.Write(myList[i] + ", ");
    }
    
    Console.WriteLine("\b\b"); //this will not work.
    
    foreach (int item in myList)
    {
        Console.Write(item + ", ");
    }
    
    //this will work:
    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
    Console.WriteLine("  ");
    
    //you can also do this, btw
    Console.WriteLine(string.Join(", ", myList) + "\b\b");
