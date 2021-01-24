    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly AppDbContext _dbContext;
    // ...
    public UniqueCodesController(IHostingEnvironment hostingEnvironment, AppDbContext dbContext)
    {
        _hostingEnvironment = hostingEnvironment;
        _dbContext = dbContext;
    }
2. If you have to keep the `GenerateExcelFile()` as `static`, you could make it accept an instance of `AppDbContext` instead of `IApplicationBuilder`:
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
and then you could invoke it as below :
        await FilesGenerationUtils.GenerateExcelFile(_dbContext, uniqueCodesHashSet, model);
 
3. Lastly, if you can't determine the type at compile-time, and want to resolve type dynamically, **you could inject an `IServiceProvider` instead of `IApplicationBuilder`**. In this way, You could resolve any instance as you like :
    private readonly IServiceProvider _sp;
    // ...
    public YourSeriveConstructor(IServiceProvider sp)
    {
        _sp = sp;
    }
    public Task AnyMethod(){
        var dbContext= this._sp.GetRequiredService<AppDbContext>();
        // or if you need a service only available within a scope 
        using(var scope = this._sp.CreateScope()){
            var _anotherDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            ...
        }
    }
