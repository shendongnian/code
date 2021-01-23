    IEnumerable array = queryObj["Capabilities"] as IEnumerable;
    if(array != null)
    {
         var csvString = String.Join(", ", array.Cast<object>().Select(x => x.ToString()));
         Console.WriteLine(csvString);
    }
    else
    {
        Console.WriteLine(queryObj["Capabilities"].ToString());
    }
