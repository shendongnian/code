    public static void Post(User item)
    {
        // Here we only have User properties to work with
        Console.WriteLine($"User Name = '{item.Name}'.");
    }
    public static void Post(ExtendedUser item)
    {
        // Do something with our extended property 
        Console.Write($"ExtendedUser: Position = '{item.Position}', ");
        // Pass the object to the overload that takes a User
        Post(item as User);
    }
