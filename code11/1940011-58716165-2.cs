public interface IContext{}
public interface IService
{
    public bool CanExecute(IContext subject);
    public IContext Execute(IContext subject);       
}
public class ServiceA:IService
{
    public bool CanExecute(IContext subject)=>true;
    public IContext Execute(IContext subject){return subject;}
}
To create an asynchronous service *without* modifying the synchronous ones, you can add a default implementation to IService and override it in new services :
public interface IService
{
    public bool CanExecute(IContext subject);
    public IContext Execute(IContext subject);
    
    public ValueTask<IContext> ExecuteAsync(IContext subject)=>new ValueTask<IContext>(Execute(subject));
    
}
public class ServiceB:IService
{
    public bool CanExecute(IContext subject)=>true;
    public IContext Execute(IContext subject)=>ExecuteAsync(subject).Result;
    
    public async ValueTask<IContext> ExecuteAsync(IContext subject)
    {
        await Task.Yield();
        return subject;
    }
}    
`ServiceB.Execute` still needs a body and one thing that makes sense is to call `ExecuteAsync()` and block, as ugly as that looks. Another possibility would be to throw if `Execute` is called :
public IContext Execute(IContext subject)=>throw new InvalidOperationException("This is an async service");
**Pattern Matching**
Another option would be to create a second interface just for the asynchronous services :
public interface IService
{
    public bool CanExecute(IContext subject);
    public IContext Execute(IContext subject);        
    
}
public interface IServiceAsync:IService
{        
    public ValueTask<IContext> ExecuteAsync(IContext subject);    
}
Both service *implementations* would remain the same. The pipeline code would change to make different calls based on the service's type :
async Task Main()
{
    IService[] pipeline=new[]{(IService)new ServiceA(),new ServiceB()};
    IContext ctx=new Context();
    foreach(var svc in pipeline)
    {
        if (svc.CanExecute(ctx))
        {
            var result=svc switch { IServiceAsync a=>await a.ExecuteAsync(ctx),
                                    IService b => b.Execute(ctx)};        
            ctx=result;
        }
    }
}
The pattern matching expression calls a different branch based on the current service's type. Natching on a type produces a strongly typed instance (a or b) which can be used to call the appropriate method.
Switch expressions are exhaustive - the compiler will generate a warning if it can't verify that all options are matched by the patterns.
**C# 7**
C# 7 doesn't have switch expressions, so the more verbose pattern matching switch statement is needed :
    if (svc.CanExecute(ctx))
    {
        switch (svc)
        {
            case IServiceAsync a:
                ctx=await a.ExecuteAsync(ctx);                    
                break;                    
            case IService b :
                ctx=b.Execute(ctx);        
                break;
            default:
                throw new InvalidOperationException("Unknown service type!");
        }
    }
Switch *statements* aren't exhaustive so we need to add the `default` section to catch errors at runtime.
