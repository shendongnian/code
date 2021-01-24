    EmployeeQuery q = new EmployeeQuery("q");
    q.Select(q.Id > (() =>
        {
            return new EmployeeQuery("e", out var q1)
            .Where(q1.Id.IsNotNull()).All();
        })
    );
  
