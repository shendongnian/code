csharp
using (var disposable = CreateIDisposable())
{
    try
    {
        // do something with the disposable.
    }
    catch (Exception e)
    {
        // do something with the exception
    }
}
