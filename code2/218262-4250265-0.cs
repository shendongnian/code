    var groups = customers.GroupBy(c => c.LastName).Where(g => g.Skip(1).Any());
    foreach(var group in groups) {
        Console.WriteLine(group.Key);
        foreach(var customer in group) {
            Console.WriteLine("\t" + customer.FirstName);
        }
    }
