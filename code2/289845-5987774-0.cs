            var searchText = "John David Clark";
            var tokens = searchText.Split(null);
            IQueryable<Employee> baseQuery = db.Employees;
            foreach (var token in tokens)
                baseQuery = baseQuery.Where(arg.FirstName == token || arg.LastName == token);
            var result = baseQuery.Select(arg => new {arg.LastName, arg.FirstName}).ToList();
