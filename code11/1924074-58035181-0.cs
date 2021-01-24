public static void Initialize(MyDbContext context)
{
    context.Database.EnsureCreated();
    
    // Create the objects you want to insert into DbContext.
    // Write it to a variable, for example, "var ExampleData".
    
    // Add example data.
    context.FiveMinStockHistory.Add(ExampleData)
    context.SaveChanges();
}
Then you could just run it on startup:
cs
    public void Configure(IApplicationBuilder app, MyDbContext context)
    {
        MyDatabaseInitializer.Initialize(context);
    }
Easy peasy. Good luck!
