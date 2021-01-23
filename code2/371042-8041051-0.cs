    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {
        Console.WriteLine(string.Format("Invoke method:{0}", input.MethodBase.ToString()));
        IMethodReturn result = getNext()(input, getNext);
        if (result.Exception == null)
        {
            Console.WriteLine("Invoke successful!");
        }
        else
        {
            Console.WriteLine(string.Format("Invoke faild, error: {0}", result.Exception.Message));
            result.Exception = null;
            Type type = ((MethodInfo)input.MethodBase).ReturnType;
            if (type.IsValueType)
            {
                result.ReturnValue = Activator.CreateInstance(type);
            }
        }
        return result;
    }
