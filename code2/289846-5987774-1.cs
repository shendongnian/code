            var searchText = "John David Clark";
            var tokens = searchText.Split(null);
            var pairs = (
                from token1 in tokens
                from token2 in tokens
                where token1 != token2
                select new { Token1 = token1, Token2 = token2 });
            IQueryable<Employee> baseQuery = db.Employees;
            foreach (var pair in pairs)
                baseQuery = baseQuery.Where(arg.FirstName == pair.Token1 && arg.LastName == pair.Token2);
            var result = baseQuery.Select(arg => new { arg.LastName, arg.FirstName }).ToList();
