class DisposableTupleContainer<D1, D2>: IDisposable
        where D1 : IDisposable
        where D2 : IDisposable
{
    private bool _disposed = false;
    private (D1, D2) _items;
    public D1 Item1 => _disposed ? throw new ObjectDisposedException("d1") : _items.Item1;
    public D2 Item2 => _disposed ? throw new ObjectDisposedException("d2") : _items.Item2;
    public DisposableTupleContainer(D1 d1, Func<D1,D2> d2) 
         // add try catch to destroy d1 if d2() throws and exception
         => _items = (d1, d2(d1)); 
    public void Dispose()
    {
        if (!_disposed)
        {
            // dispose d1, d2, handle exception
            _disposed = true;
        }
    }
}
`d2` is a functor so that you can chain construction of disposable objects:
using(var container = new DisposableTupleContainer(
   new SqlCommand(someSelectQuery, conn, transaction), 
   c => c.ExecuteReader())) 
{
  //  container.Item2 is your reader
}
This option gives you strong typing. It is something similar to what you have now. I don't consider it very elegant though :), option with a factory method or just nesting `using` looks more common to me.
Please note that C# 8 contains some [improvements](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations) to `using`, now you can just specify it on declaration:
using var cmd = new SqlCommand(someSelectQuery, conn, transaction);
using var reader = cmd.ExecuteReader();
