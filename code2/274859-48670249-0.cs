    object expectedValue = (int) 42;
    object testValue = (long) 42;
    
    // This handles equal values stored as different types, such as int vs. long.
    if (testValue is IConvertible testValueConvertible
        && expectedValue is IConvertible)
    {
        testValue = testValueConvertible
            .ToType(expectedValue.GetType(),
                    System.Globalization.CultureInfo.InvariantCulture);
    }
    
    if (object.Equals(testValue, expectedValue))
        Console.WriteLine("Values are equal");
    else
        Console.WriteLine("Values are NOT equal");
