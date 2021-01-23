        Console.WriteLine(stringArray.Last());
        if (stringArray.Any())
            Console.WriteLine(stringArray.ElementAt(stringArray.Count()-1));
        Console.WriteLine(stringArray[stringArray.Length -1]);
        var stringEnum = stringArray.GetEnumerator();
        string lastValue = null;
        while (stringEnum.MoveNext())
            lastValue = (string)stringEnum.Current;
        Console.WriteLine(lastValue);
