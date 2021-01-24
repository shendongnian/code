    foreach (PropertyInfo prop in myBase.GetType().GetProperties())
    {
        // this returns object
        var element = prop.GetValue(myBase, null);
        Console.WriteLine(element);
    }
