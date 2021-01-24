    public class MyService
    {
        private MyContext Context => new MyContext(new DbContextOptions<MyContext>()));
    
        private async Task DoSomething()
        {
            await using var context = this.Context;  //New context for the lifetime of this method
            var r = await context.Something
                .Where(d => d....)
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
    
             // context gets disposed of
             // Other code
        }
        private async Task DoSomethingElse()
        {
            await using var context = this.Context;   //New context for the lifetime of this method
            var r = await context.Something
                .Where(d => d....)
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
    
             // context gets disposed of
             // Other code
        }
    }
