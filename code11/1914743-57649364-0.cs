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
Also don't forget to make the method containing the foreach loop `async`. You can await Tasks only in `async` methods.
c#
public async void Foo()
{
    foreach(var itm in Items)
    {
        await MyFunction(itm);
    }
}
