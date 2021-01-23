    Dictionary<string, List<Employee>> groups =
           new Dictionary<string, List<Employee>>();
    foreach(Employee emp in employees) {
        List<Employee> group;
        if(!groups.TryGetValue(emp.Category, out group)) {
            group = new List<Employee>();
            groups.Add(emp.Category, group);
        }
        group.Add(emp);
    }
    foreach(KeyValuePair<string,List<Employee>> pair in groups) {
        Console.WriteLine(pair.Key);
        foreach(Employee emp in pair.Value) {
            Console.WriteLine(emp.Id);
        }
    }
