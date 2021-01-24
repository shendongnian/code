    public MyDbContext CreateSqliteContext()
    {
        var connectionString = 
            new SqliteConnectionStringBuilder { DataSource = ":memory:" }.ToString();
        var connection = new SqliteConnection(connectionString);
        var options = new DbContextOptionsBuilder<MyDbContext>().UseSqlite(connection);
        return new MyDbContext(options);
    }
    private void Insert(Work work)
    {
        using (var context = CreateSqliteContext())
        {
            context.Works.Add(work);
            context.SaveChanges();
        }    
    }
    [Fact]
    public void Post_InsertDuplicateWork_ShouldThrowException()
    {
        var work1 = new Work { Name = "Test Work" };
        var work2 = new Work { Name = "Test Work" };
        Insert(work1);
        Action saveDuplicate = () => Insert(work2);
        saveDuplicate.Should().Throw<DbUpdateException>(); // Pass Ok
    }
