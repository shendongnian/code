    string x = null;
    foreach (var item in items)
    {
        if (x != item.name)
        {
            x = item.name;
            Console.WriteLine(item.id);
        }
    }
