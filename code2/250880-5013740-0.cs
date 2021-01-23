    foreach (Var group in query)
    {
        Console.WriteLine("Group: {0}", group.Key);
        foreach (var student in group)
        {
            Console.WriteLine("  {0}", student.Grade);
        }
    }
