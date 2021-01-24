    var max0 = GetMaxLengthOfColumnInSlownik(0, slownik);
    var max1 = GetMaxLengthOfColumnInSlownik(1, slownik);
    var max2 = GetMaxLengthOfColumnInSlownik(2, slownik);
    for (int i=0; i<10; i++)
    { 
        var column1String = slownik[i, 0].Length< max0? AppendSpaces(slownik[i, 0], max0); 
        var column2String = slownik[i, 1].Length< max1? AppendSpaces(slownik[i, 1], max1); 
        var column2String = slownik[i, 2].Length< max2? AppendSpaces(slownik[i, 2], max1); 
     
        Console.WriteLine(column1String  + "  \t " + column2String  + "  \t  " + column3String);
    }
