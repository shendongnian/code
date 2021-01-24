    public static void GetDisplayName(object anyType, string displayName)
    {
        var type = anyType.GetType();
        var displayProperty = type.GetProperty(displayName);
        if (displayProperty != null)
        {
            Console.WriteLine($"DisplayName is {displayProperty.GetValue(anyType)}");
            return;
        }
        var displayFiled = type.GetField(displayName);
        if (displayFiled != null)
        {
            Console.WriteLine($"DisplayName is {displayFiled.GetValue(anyType)}");
            return;
        }
        // can't find displayName
        Console.WriteLine($"DisplayName is {type.Name}");
    }
