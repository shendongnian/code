csharp
public void ActionWrapper(Action action)
{
  using(var I = new Impersonator("user", ".", "password"))
  {
    action.Invoke();
  }
}
So the question is: How to apply this method efficiently?
Let's assume your existing class is:
csharp
public class FileCopier
{
    public void CopyFile(string filePath, string destPath)
    {
        // Do stuff
    }
}
You could, as you suggested, create a derived class to add impersonation:
csharp
public class FileCopierWithImpersonation : FileCopier
{
    public void CopyFile(string filePath, string destPath)
        => WithImpersonation(base.CopyFile(filePath, destPath));
    public void WithImpersonation(Action action)
    {
      using(var I = new Impersonator("user", ".", "password"))
      {
        action.Invoke();
      }
    }
}
Here, `FileCopierWithImpersonation` serves as a decorator over `FileCopier`, implemented via inheritance. The `WithImpersonation` method serves as an interceptor that can apply an impersonation scope over any method.
That should work well enough, but it forces some compromises in implementation. The base class's methods will all need to be marked as `virtual`. The child class's constructor might need to pass arguments to the base class. It will be impossible to unit test the child class's logic independently of the base class's logic.
So, you might want to extract an interface (`IFileCopier`) and apply the decorator using composition rather than inheritance:
csharp
public class FileCopierWithImpersonation : IFileCopier
{
    private readonly IFileCopier _decoratee;
    public FileCopierWithImpersonation(IFileCopier decoratee)
    {
         // If you don't want to inject the dependency, you could also instantiate
         // it here: _decoratee = new FileCopier();
        _decoratee = decoratee;
    }
    public void CopyFile(string filePath, string destPath)
        => WithImpersonation(_decoratee.CopyFile(filePath, destPath));
    public void WithImpersonation(Action action)
    {
      using(var I = new Impersonator("user", ".", "password"))
      {
        action.Invoke();
      }
    }
}
If you're using Visual Studio 2019, there's a refactoring option to "Implement Interface through..." that will automatically implement an interface by calling methods of a dependency of the same type. After that, a simple find/replace should be all that's needed to add the interceptor. I don't have VS available at the moment, but I'll try to upload a gif showing the feature later.
You could also look into code generation tools, like [T4 Templates](https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates) to auto-generate the decorators. Beware, though, that T4 is not supported in .NET Core. It looks to be a legacy technology at this point.
