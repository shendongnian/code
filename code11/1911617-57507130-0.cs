    IQueryable<Row> queryable = new List<Row>
    {
        new Row { Id = 1, Name = "John", CityId = 1, UserId = null },
        new Row { Id = 2, Name = "John", CityId = null, UserId = 2 },
        new Row { Id = 3, Name = "Jack", CityId = 1, UserId = null },
        new Row { Id = 4, Name = "John", CityId = 2, UserId = null },
    }.AsQueryable();
