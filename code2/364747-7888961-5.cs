    var firstString = "bc3231dsc";
    var secondString = "bc3462dsc";
    var commonChars = CommonChars(firstString, secondString);
    var packs = Pack(commonChars);
    foreach (var item in packs)
    {
        Console.WriteLine("Left side:  " + firstString.Substring(item.Item1, item.Item2));
        Console.WriteLine("Right side: " + secondString.Substring(item.Item1, item.Item2));
        Console.WriteLine();
    }
