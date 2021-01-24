    [Fact]
    public void Post_InsertDuplicateWork_ShouldThrowException()
    {
        var work = new Work
        {
            Name = "Test Work"
        };
    
        using (var context = new MyDbContext (options))
        {
            context.Works.Add(work);
            context.SaveChanges();
        }
    
        using (var context = new MyDbContext (options))
        {
            context.Works.Add(work);
            Assert.Throws<Exception>(() => context.SaveChanges());
        }
    }
