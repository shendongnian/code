    foreach (var item in projects.Values)
    {
        if (PropertiesOfType<bool>(item).Any(property => property.Value))
            Console.WriteLine($"{item} has a true bool.");
    }
