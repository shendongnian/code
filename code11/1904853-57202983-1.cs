    foreach (var itemA in listA)
    {
        var found = false;
        foreach (var itemB in listB)
        {
            if (itemA.TableName == itemB.TableName)
            {
                found = true;
            }
        }
        if (found == false)
        {
            Console.WriteLine("ItemA's TableName wasn't found in listB");
        }
    }
