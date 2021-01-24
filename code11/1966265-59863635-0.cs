private readonly SemaphoreSlim methodLock = new SemaphoreSlim(1, 1);
public async Task SomeMethod()
{
    await methodLock.WaitAsync();
    try
    {
        ...
    }
    finally
    {
        methodLock.Release();
    }
}
If you're feeling adventurous, you can write an extension method on `SemaphoreSlim`, letting you do e.g.:
public async Task SomeMethod()
{
    using (await methodLock.WaitDisposableAsync())
    {
        ...
    }
}
