c#
foreach(var itm in Items)
{
    await MyFunction(itm);
}
// you must return Task to await it. void won't work
private Task MyFunction(int value)
{
    // Task.Run is preferred over Task.Factory.StartNew,
    // although it won't make any difference
    return Task.Run(() => MyFunction2(value));
}
Also don't forget to make the method containing the foreach loop `async Task`. You can await Tasks only in `async` methods. Return type should be `Task`, so you can later await it and possibly catch exceptions. Avoid `async void`, unless the method is an event handler.
c#
public async Task Foo()
{
    foreach(var itm in Items)
    {
        await MyFunction(itm);
    }
}
