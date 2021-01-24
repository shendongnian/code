    int I = 2, J = 3;
    var a = new ArrayND<int>(new[] { I, J });
    var v = 0;
    for (var i = 0; i < I; i++)
        for (var j = 0; j < J; j++)
            a.SetValue(++v, new[] { i, j });
    var b = a.ToOneD();
    var c = ArrayND<int>.FromOneD(b, new[] { I, J });
    Console.WriteLine(a.Equals(c)); // True
