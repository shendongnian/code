    public static void Compare(Type someType, Type otherType)
    {
        var listOfSomeTypeType = typeof(List<>).MakeGenericType(someType);
        var arrayOfSomeTypeType = someType.MakeArrayType();
        Console.WriteLine("SomeType: {0}",someType.Name);
        Console.WriteLine("OtherType: {0}",otherType.Name);
        if(someType == otherType)
            Console.WriteLine("someType and otherType are the same");
        else if(listOfSomeTypeType == otherType)
            Console.WriteLine("otherType is a list of someType");
        else if(arrayOfSomeTypeType == otherType)
            Console.WriteLine("otherType is an array of someType");
        else
            Console.WriteLine("No match found");
    }
