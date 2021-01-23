        Console.WriteLine(stringArray.First());
        Console.WriteLine(stringArray.ElementAt(0));
        Console.WriteLine(stringArray[0]);
        var stringEnum = stringArray.GetEnumerator();
        if (stringEnum.MoveNext())
            Console.WriteLine(stringEnum.Current);
