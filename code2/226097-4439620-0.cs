    IEnumerable<EmployeeExpense> GetEmployeeExpenses(List<ExpenseClaim> claims)
    {
        return 
            from c in claims
            group c by c.EmployeeId into groupedById
            from g in groupedById
            group g by g.Team into groupedByTeam
            let firstElement = groupedByTeam.First()
            select new EmployeeExpense {
                EmployeeId = firstElement.EmployeeId,
                Team = firstElement.Team,
                Cost = groupedByTeam.Sum(e => e.Cost)
            };
    }
