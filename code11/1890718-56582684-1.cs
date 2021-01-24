    List<Row> users = new List<Row>()
    {
        new Row("John", "Doe", "10"),
        new Row("John", "Doe", "45"),
        new Row("Will","Smith", "26"),
        new Row("Will", "Smith", "52"),
        new Row("Julius", "Cesar", "23")
    };
    List<int> groupingColumnIndexes = new List<int>() { 0, 1 };
    List<User> output = users
                .GroupBy(x =>
                     groupingColumnIndexes.Select(c => x.ColumnValues[c]).ToList(),
                     new StringColumnEqualityComparer()
                )
                .Select(x => new User
                {
                    Name = string.Join(',', x.Key),
                    Age = (int)x.Sum(a => int.Parse(a.ColumnValues[2])),
                    LastName = string.Empty
                }).ToList();
