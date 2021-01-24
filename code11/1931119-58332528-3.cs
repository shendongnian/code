    public static void Post(User user)
    {
        // Check if 'user' is an 'ExtendedUser', and if it is, show the postion property
        var extUser = user as ExtendedUser;
        if (extUser != null) Console.Write($"ExtendedUser: Position = '{extUser.Position}', ");
        // Here we only have User properties to work with
        Console.WriteLine($"User Name = '{user.Name}'.");
    }
