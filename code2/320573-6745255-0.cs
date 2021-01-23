    User user = ...
    foreach(PropertyInfo prop in typeof(User).GetProperties())
    {
        Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(user, null));
    }
