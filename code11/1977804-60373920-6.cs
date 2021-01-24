    foreach (var item in projects.Values)
    {
        foreach (var boolProperty in PropertiesOfType<bool>(item))
        {
            if (!boolProperty.Value)
                Console.WriteLine($"bool {boolProperty.Key} is false.");
        }
    }
