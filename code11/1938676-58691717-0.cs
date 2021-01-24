public class Program : INotifyDataErrorInfo
{
    public int Id { get; set; }
    public static void Main()
    {
        var p1 = new Program { Id = 1 };
        var p2 = new Program { Id = 2 };
        var mi = typeof(ErrorsChangedEventManager).GetMethod(nameof(ErrorsChangedEventManager.AddHandler),
            BindingFlags.Public | BindingFlags.Static);
        var source = Expression.Parameter(typeof(INotifyDataErrorInfo), "source");
        var program = Expression.Parameter(typeof(Program), "program");
        
        Expression<Func<Program, EventHandler<DataErrorsChangedEventArgs>>> createDelegate = p => p.OnError;
        var createDelegateInvoke = Expression.Invoke(createDelegate, program);
        var call = Expression.Call(mi, source, createDelegateInvoke);
        var expr = Expression.Lambda<Action<INotifyDataErrorInfo, Program>>(call, source, program);
        var action = expr.Compile();
        action(p1, p2);
        p1.ErrorsChanged.Invoke(p1, new DataErrorsChangedEventArgs("Foo"));
    }
    public void OnError(object sender, DataErrorsChangedEventArgs e)
    {
        if (sender is Program p)
        {
            Console.WriteLine($"OnError called for Id={Id}. Expected Id=2");
        }
    }
    public IEnumerable GetErrors(string propertyName) => Enumerable.Empty<string>();
    public bool HasErrors => false;
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
}
If you look at the DebugView for `createDelegate`, you can see that the compiler created:
.Lambda #Lambda1<System.Func`2[Program,System.EventHandler`1[System.ComponentModel.DataErrorsChangedEventArgs]]>(Program $p)
{
    (System.EventHandler`1[System.ComponentModel.DataErrorsChangedEventArgs]).Call .Constant<System.Reflection.MethodInfo>(Void OnError(System.Object, System.ComponentModel.DataErrorsChangedEventArgs)).CreateDelegate(
        .Constant<System.Type>(System.EventHandler`1[System.ComponentModel.DataErrorsChangedEventArgs]),
        $p)
}
You could construct this expression yourself if you wanted, by getting the `MethodInfo` for `OnError`, then calling `CreateDelegate` on it.
