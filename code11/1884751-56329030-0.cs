    System.Globalization.DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
    foreach(var name in dtFormat.AbbreviatedMonthGenitiveNames)
    {
        Console.WriteLine(name);
    }
