    public static ResourceItem GetById(int id)
    {
        WithDataContext(db =>
        {
            // Code goes here...
        });
    }
    // Other methods here, all using WithDataContext
    // Now the only method with a using statement:
    private static T WithDataContext<T>(Func<TestDataContext, T> function)
    {
        using (var db = DataContextFactory.Create<TestDataContext>())
        {
            return function(db);
        }
    }
