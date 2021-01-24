    EmployeesQuery q = new EmployeesQuery("q");
    q.Where(q.EmployeeID > (() =>
        {
            return new EmployeesQuery("e", out var q1)
            .Select(q1.EmployeeID)
            .Where(q1.EmployeeID.IsNotNull()).Any();
        })
    );
