    var highestEnum = (int)Enum.GetValues(typeof(MyFlagsEnum)).Cast<MyFlagsEnum>).Max();
    var upperBound = highestEnum * 2;    
    for (int i = 0; i < upperBound; i++)
    {
        Console.WriteLine(((MyFlagsEnum)i).ToString());
    }
