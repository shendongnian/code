    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly AppDbContext _dbContext;
    // ...
    public UniqueCodesController(IHostingEnvironment hostingEnvironment, AppDbContext dbContext)
    {
        _hostingEnvironment = hostingEnvironment;
        _dbContext = dbContext;
    }
2. I believe it would be much easier if you change the `GenerateExcelFile()` from a `static` method to an `instance` method. By this way, you'll be able to reuse the field of `AppDbContext`:
    public async Task GenerateExcelFile(IEnumerable hashSetCodes, ContestViewModel model)
    {
        ...
        try{
            var contest = new Contest
            {
                Name = model.ProjectName,
                UserId = 1,
                FileGenerationStatus = true,
                FilePath = fileInfo.FullName
            };
            _dbcontext.Contests.Add(contest);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
3. If you have to keep the `GenerateExcelFile()` as `static`, you could make it accept an instance of `AppDbContext` instead of `IApplicationBuilder`:
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
4. Lastly, if you can't determine the type at compile-time, and want to resolve type dynamically, **you could inject an `IServiceProvider` instead of `IApplicationBuilder`**. In this way, You could resolve any instance as you like :
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly AppDbContext _dbContext;
    private readonly IServiceProvider _sp;
    // ...
    public UniqueCodesController(IHostingEnvironment hostingEnvironment, AppDbContext dbContext, IServiceProvider sp)
    {
        _hostingEnvironment = hostingEnvironment;
        _dbContext = dbContext;
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
