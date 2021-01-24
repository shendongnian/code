    if (o is IEnumerable && o is IEnumerable<string>)
    {             
        Console.WriteLine(string.Join("|", (o as IEnumerable<string>)));             
    }
    else
    {
         Console.WriteLine(o.ToString());
    }
