    var type = o.GetType();
    var members = type.GetMembers(BindingFlags.NonPublic|BindingFlags.Public);
    foreach(var member in members)
    {
        var field = type.GetField(member.Name);
        Console.WriteLine(field.GetValue(o));
    }
