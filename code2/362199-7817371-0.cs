    object o = user["user_id"];
    if (o == null)
    {
        Console.WriteLine("user_id is null");
    }
    else
    {
        Console.WriteLine("Actual type of user_id: {0}", o.GetType());
    }
