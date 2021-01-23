    List<int> GetBands(int numBands)
    {
        using(var db = new MyContext())    
        {
            var list SalaryBands = new List<int>();
            var count = db.People.Count();
            var salaries = db.People.OrderBy(item => item.Salary)
                                    .Select(item => item.Salary);
            int skipCount = count / numBands;
            for(int segmentNum = 0; segmentNum < numBands; segmentCount++)
            {
                salaries = salaries.Skip(skipCount);
                salaryBands.Add(salaries.First());
            }
            return salaryBands;
        }
    }
