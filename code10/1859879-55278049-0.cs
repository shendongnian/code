    private static Employee FindSecondHighest(IEnumerable<Employee> employees) {
        var list = employees.ToList();
        if (list.Count == 1) { return list[0]; }
        return list.OrderByDescending(x => x.Salary).Skip(1).First();
    }
