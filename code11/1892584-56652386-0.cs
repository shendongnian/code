    static async Task Main(string[] args)
    {
        var host = Host
            .CreateDefaultBuilder(args)             
            .ConfigureServices((context, services) =>
            {
                var configuration = context.Configuration;
                services.AddDbContext<MyContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("someConnection")));                    
            })                
            .Build();
        using(var ctx=host.Services.GetRequiredService<MyContext>())
        {
            var cnt=await ctx.Customers.CountAsync();
            Console.WriteLine(cnt);
        }            
    }
