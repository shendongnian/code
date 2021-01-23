    ArrayList list = new ArrayList();
    list.Add(1); // These are all boxing - the integer is getting boxed to add
    list.Add(2);   
    list.Add(3);
    foreach(object item in list)
    {
        // Unboxing required here:
        int value = (int)item;
        Console.WriteLine(value);
    }
