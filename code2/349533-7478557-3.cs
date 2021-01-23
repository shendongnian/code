    void Main()
    {
        Foo foo = new Foo();
        var args = new object[0];
        var method = typeof(Foo).GetMethod("DoSomething");
        dynamic dfoo = foo;
        var precompiled = 
            Expression.Lambda<Action>(
                Expression.Call(Expression.Constant(foo), method))
            .Compile();
        var lazyCompiled = new Lazy<Action>(() =>
            Expression.Lambda<Action>(
                Expression.Call(Expression.Constant(foo), method))
            .Compile(), false);
        var wrapped = Wrap(method);
        var lazyWrapped = new Lazy<Func<object, object[], object>>(() => Wrap(method), false);
        var actions = new[]
        {
            new TimedAction("Direct", () => 
            {
                foo.DoSomething();
            }),
            new TimedAction("Dynamic", () => 
            {
                dfoo.DoSomething();
            }),
            new TimedAction("Reflection", () => 
            {
                method.Invoke(foo, args);
            }),
            new TimedAction("Precompiled", () => 
            {
                precompiled();
            }),
            new TimedAction("LazyCompiled", () => 
            {
                lazyCompiled.Value();
            }),
            new TimedAction("ILEmitted", () => 
            {
                wrapped(foo, null);
            }),
            new TimedAction("LazyILEmitted", () => 
            {
                lazyWrapped.Value(foo, null);
            }),
        };
        TimeActions(1000000, actions);
    }
    
    class Foo{
        public void DoSomething(){}
    }
    
    static Func<object, object[], object> Wrap(MethodInfo method)
    {
        var dm = new DynamicMethod(method.Name, typeof(object), new Type[] {
            typeof(object), typeof(object[])
        }, method.DeclaringType, true);
        var il = dm.GetILGenerator();
    
        if (!method.IsStatic)
        {
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, method.DeclaringType);
        }
        var parameters = method.GetParameters();
        for (int i = 0; i < parameters.Length; i++)
        {
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldc_I4, i);
            il.Emit(OpCodes.Ldelem_Ref);
            il.Emit(OpCodes.Unbox_Any, parameters[i].ParameterType);
        }
        il.EmitCall(method.IsStatic || method.DeclaringType.IsValueType ?
            OpCodes.Call : OpCodes.Callvirt, method, null);
        if (method.ReturnType == null || method.ReturnType == typeof(void))
        {
            il.Emit(OpCodes.Ldnull);
        }
        else if (method.ReturnType.IsValueType)
        {
            il.Emit(OpCodes.Box, method.ReturnType);
        }
        il.Emit(OpCodes.Ret);
        return (Func<object, object[], object>)dm.CreateDelegate(typeof(Func<object, object[], object>));
    }
