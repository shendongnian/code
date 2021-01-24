public static Action<Caller> GetCallerAction(Caller caller)
{
  return delegate { caller.CallerName = "Test Again"; };
}
and pass Caller with dependencies into that method:
IServiceProvider serviceProvider = new MyServiceProvider(); 
var c2 = new Caller(serviceProvider);
Helper.DoSomething(GetCallerAction(c2));
