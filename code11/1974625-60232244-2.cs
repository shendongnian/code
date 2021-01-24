    string str = "4x^2 + 6x^5 -12y + 3xy";
    string strCopy = str;
    if (str.Length != 0 && str[0] != '-') // covers case when first member is positive, if it is not enough you can use str.TrimStart()[0]
    {
        strCopy = "+" + str;
    }
    var reverseString = string.Join(" ", strCopy
        .Replace(" ", "") // remove all spaces because they kind of random now
        .Replace("+", " +") // add space to signs to keep them with their value
        .Replace("-", " -")
        .Split(' ')
        .Reverse()
    )
    .TrimStart('+') // remove plus if positive number on the right
    .Replace(" +", " + ") // fix spaces back
    .Replace(" -", " - ");
    Console.WriteLine(strCopy);
    Console.WriteLine(reverseString);
    Console.ReadKey();
