    var cutoff=DateTime.Today.AddYears(-50);
    var sqlQuery = @"select Person.BusinessEntityID as PersonID, Person.LastName,
                Person.FirstName,
                Employee.BusinessEntityID as EmployeeID,
                Employee.Gender,
                Employee.BirthDate,
                Employee.HireDate,
                DATEDIFF(YEAR, Employee.BirthDate, GETDATE()) as Age
            FROM Person.Person
                JOIN HumanResources.Employee
                ON Person.BusinessEntityID = Employee.BusinessEntityID
            WHERE Employee.BirthDate <= @cutoff
            ORDER BY Age DESC";
    var employeesAge = _con.Query<Person, Employee, EmployeeAgeViewModel>(sqlQuery,
                            new {cutoff},
                           (per, emp) => new EmployeeAgeViewModel()
                            {
                                FirstName = per.FirstName,
                                LastName = per.LastName,
                                Gender = emp.Gender == "M" ? Models.Helpers.Enums.Gender.M : Models.Helpers.Enums.Gender.F,
                                BirthDate = emp.BirthDate,
                                HireDate = emp.HireDate,
                                Age = emp.Age 
                            },
                            splitOn: "EmployeeID")
                            .ToList();
