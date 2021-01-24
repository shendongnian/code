    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly AppDbContext _dbContext;
    // ...
    public UniqueCodesController(IHostingEnvironment hostingEnvironment, AppDbContext dbContext)
    {
        _hostingEnvironment = hostingEnvironment;
        _dbContext = dbContext;
    }
And then change the `GenerateExcelFile()` to accept a parameter of `AppDbContext`
    <strike>public static async Task GenerateExcelFile(IApplicationBuilder app, IEnumerable&lt;string&gt;hashSetCodes, ContestViewModel model)</strike>
    public static async Task GenerateExcelFile(AppDbContext dbContext, IEnumerable<string> hashSetCodes, ContestViewModel model)
    {
        ...
        try{
            <strike>var context = app.ApplicationServices.GetRequiredService<AppDbContext>();</strike>
            var contest = new Contest
            {
                Name = model.ProjectName,
                UserId = 1,
                FileGenerationStatus = true,
                FilePath = fileInfo.FullName
            };
            <strike>context.Contests.Add(contest);</strike>
            context.Contests.Add(contest);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
Finally, you could invoke it as below :
        await FilesGenerationUtils.GenerateExcelFile(_dbContext, uniqueCodesHashSet, model);
----------
As a side note, if you can't determine the required type at compile-time, and want to resolve some service type dynamically, **you could inject an `IServiceProvider` instead of the `IApplicationBuilder`**. In this way, You could resolve any instance as you like :
    var dbContext= sp.GetRequiredService<AppDbContext>();
    // or if you need a service only available within a scope 
    using(var scope = this._sp.CreateScope()){
        var _anotherDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        ...
    }
Taking your code as an example, you could pass an `IServiceProvider` to `GenerateExcelFile(IServiceProvider sp, IEnumerable<string> hashSetCodes, ContestViewModel model)`, and within the `GenerateExcelFile()` method, you could resolve the `AppDbContext` in the following way:
    public static async Task GenerateExcelFile(IServiceProvider sp, IEnumerable<string> hashSetCodes, ContestViewModel model)
    {
        ...
        var dbContext= sp.GetRequiredService<AppDbContext>();
        try{
            var contest = new Contest
            {
                Name = model.ProjectName,
                UserId = 1,
                FileGenerationStatus = true,
                FilePath = fileInfo.FullName
            };
          
            dbContext.Contests.Add(contest);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
