    bool insertExists = false;
    bool loadExists = false;
    bool saveExists = false;
    while (list_SP.Read())
    {
        if (list_SP[0].ToString().EndsWith("Insert"))
        {
            insertExists = true;
        }
        if (list_SP[0].ToString().EndsWith("Load"))
        {
            loadExists = true;
        }
        if (list_SP[0].ToString().EndsWith("Save"))
        {
            saveExists = true;
        }
        if (insertExists && loadExists && saveExists)
        {
            Console.WriteLine("All three exist");
            break;
        }
    }
    if (!insertExists)
    {
        Console.WriteLine("Missing insert");
    }
    if (!loadExists)
    {
        Console.WriteLine("Missing load");
    }
    if (!saveExists)
    {
        Console.WriteLine("Missing save");
    }
