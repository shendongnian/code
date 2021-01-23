    method = _v as MethodInfo;
    object[] parameters = null;
    Thread UIthread = new Thread(() =>
    {
        object obj = null;
        if (!method.IsStatic)
        {
            obj = Activator.CreateInstance(method.DeclaringType);
        }
        method.Invoke(obj, parameters);
    });
    UIthread.Start();
