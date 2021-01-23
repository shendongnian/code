    var list11 = new List<double> { 1, 2, 3 };
    var list22 = new List<double> { 4, 5, 3 };
    var list33 = new List<double> { 4, 1, 0 };
    int acounter = 0, bcounter = 0, ccounter;
    list11.Select((o, i) => new { a = list11[i], b = list22[i] })
        .Aggregate(0, (init, item) => item.a > item.b
                                            ? acounter++
                                            : item.a == item.b
                                                ? bcounter
                                                : bcounter++);
    if (acounter > bcounter)
    {
        //Do the same for list11 and list33
    }
    else
    {
        //Do the same for list22 and list33 
    }
