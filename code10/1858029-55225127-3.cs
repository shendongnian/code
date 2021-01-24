    DbConnection inMemoryDbConnection = Effort.DbConnectionFactory.CreatePersistent(testDbName);
    using(var schoolDbContext = new SchoolDbContext(inMemoryConnection);
    {
        // TODO: fill the database with test values
        ...
        IEqualityComparer<Student> studentComparer = ...
        var expectedObsoleteStudents = schoolDbContext.Students
            .Where(student => student.Obsolete)
            .ToHashSet(studentComparer);
        // Perform the Test:
        var testObject = new MyClassThatUsesADataBase()
        {
             SchoolDbContext = schoolDbContext();
        }
        // Test function: FetchObsoleteStudents, and check that the expected students are fetched
        var obsoleteStudents = testObject.FetchObsoleteStudents();
        Assert.IsTrue(expectedObsoleteStudents.EqualSet(obsoleteStudents);
    }
