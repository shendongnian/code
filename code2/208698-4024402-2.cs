    private Dictionary<Type, Action<object>> _TypeExecutor;
    private void SetupExecutors()
    {
        _TypeExecutor = new Dictionary<Type, Action<object>>();
        _TypeExecutor.Add(typeof(Service1), new Action<object>((target) => target.DoSomething()));
        _TypeExecutor.Add(typeof(Service2), new Action<object>((target) =>
            {
                var instance = (Service2)target;
                var result = instance.DoSomething();
            }));
        _TypeExecutor.Add(typeof(Service3), AnotherMethod);
    }
    private void AnotherMethod(object target)
    {
        var instance = (Service3)target;
        var result = instance.DoSomething();
    }
    private void DoWork(ISomething something)
    {
        Action<object> action;
        if (_TypeExecutor.TryGetValue(something.GetType(), out action))
        {
            action(something);
        }
    }
