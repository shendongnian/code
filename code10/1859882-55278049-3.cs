    private static Employee FindSecondHighest(IEnumerable<Employee> employees) {
        var list = employees.ToList();
        if (list.Count == 1) { return list[0]; }
        return list.GroupBy(x => x.Salary).OrderByDescending(x => x.Key).Skip(1).First();
    }
