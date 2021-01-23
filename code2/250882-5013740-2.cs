    foreach (var group in query)
    {
        Console.WriteLine("Group: {0}", group.Name);
        foreach (var student in group.Students)
        {
            Console.WriteLine("  {0}", student.Grade);
        }
    }
