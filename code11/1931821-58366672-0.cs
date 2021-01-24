    var data = new List<NumberModel>
    {
        // Sample data
        new NumberModel{Hour=1,Total=40},
    	new NumberModel{Hour=3,Total=23},
        new NumberModel{Hour=6,Total=12}
    };
    for (int i=1; i<=23; ++i)
    {
        Console.Write($"{i}=");
        Console.WriteLine (data.Any(x => x.Hour==i)
            ? data.First(x => x.Hour==i).Total
            : 0);
    }
