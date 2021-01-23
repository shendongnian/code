    var highestEnum = Enum.GetValues(typeof(MyEnum)).Cast<int>().Max();
    var upperBound = highestEnum * 2;    
    for (int i = 0; i < upperBound; i++)
    {
        Console.WriteLine(((MyEnum)i).ToString());
    }
