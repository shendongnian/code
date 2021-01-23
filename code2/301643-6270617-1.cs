    var q = 
      (from employee in Database.Employees
      where !Database.Customers.Any(c => employee.FirstName == c.FirstName) &&
        employee.IsEmployeeActive
      select new
      {
        employee.EmployeeId,
        employee.FirstName,
        employee.LastName
      }).Union(
      from customer in Database.Customers
      select new
      {
        customer.CustomerID,
        customer.FirstName,
        customer.LastName
      });
