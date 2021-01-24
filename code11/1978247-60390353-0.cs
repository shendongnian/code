public class DisposableFoo : IDisposable
{
    // Assume FooConcrete implements IFoo and IDisposable
    private readonly FooConcrete _foo;
    public DisposableFoo(FooConcrete fooConcrete) { _foo = fooConcrete; }
    public IFoo Instance => _foo;
    public void Dispose() => _foo.Dispose();
}
And then in `Startup.cs` you could do the following to keep your abstractions clean:
services.AddTransient<FooConcrete>();
services.AddScoped<DisposableFoo>();
services.AddScoped<IFoo>(ctx => ctx.Resolve<DisposableFoo>.Instance); 
In this case the underlying `FooConrecte` will be disposed at the end of scope lifetime properly.
