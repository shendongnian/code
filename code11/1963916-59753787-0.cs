    public interface IFoo 
    {
        Task DoSomething();
    }
    
    public class Foo: IFoo
    {
       private readonly DbContext _dbContext;
    
       public Foo(DbContext dbContext)
       {
         _dbContext = dbContext;
       }
    
       public async Task DoSomething()
       {
           // Do something here with `DbConext`
       }
    }
