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
