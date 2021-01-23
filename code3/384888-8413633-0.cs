    void PrintEnumValues<TEnum>() 
    {
        if (!typeof(Enum).IsAssignableFrom(typeof(TEnum)))
        {
            return;
        }
        foreach (var name in Enum.GetNames(typeof(TEnum)))
        {
            // Print name
        }
    }
