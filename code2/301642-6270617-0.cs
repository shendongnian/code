    var q = 
      (from employee in Database.Employees
      where !Database.Customers.Any(c => employee.FirstName == c.FirstName)
      select new
      {
        employee.EmployeeId,
        employee.FirstName,
        employee.LastName
      }).Union(
      from user in Database.Customers
      select new
      {
        Customer.CustomerID,
        Customer.FirstName,
        Customer.LastName
      });
