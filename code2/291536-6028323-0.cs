    IEnumerable array = queryObj["Capabilities"] as IEnumerable;
    if(array != null)
    {
        foreach(var item in array)
        {
            Console.WriteLine(item.ToString());
        }
    }
    else
    {
        Console.WriteLine(queryObj["Capabilities"].ToString());
    }
