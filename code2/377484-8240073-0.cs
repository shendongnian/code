    private IEnumerable<object> argumentsForConstructor;
    public object Invoke(IEnumerable<object> parameters)
    {
        this.argumentsForConstructor = parameters;
        Type actionType = typeof(Action<>).MakeGenericType(
             typeof(IFakeOptionsBuilder<>).MakeGenericType(this.targetType));
        MethodInfo actionMethod = this.GetType()
            .GetMethod("SetArgumentsForConstructor", BindingFlags.Instance | BindingFlags.NonPublic)
            .MakeGenericMethod(new[] { this.targetType });
        Delegate action = Delegate.CreateDelegate(actionType, this, actionMethod);
        Type fake = typeof(Fake<>).MakeGenericType(this.targetType);
        ConstructorInfo ctor = (from ci in fake.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                                from pi in ci.GetParameters()
                                where pi.ParameterType == actionType
                                select ci).First();
        return ctor.Invoke(new[] { action });
    }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This method is used by Reflection. It describes the method that is passed in the Action<IFakeOptionsBuilder<T>> overload of the Fake<T> constructor.")]
    private void SetArgumentsForConstructor<T>(IFakeOptionsBuilder<T> o)
    {
        if (typeof(T).IsInterface)
        {
            return;
        }
        o.WithArgumentsForConstructor(this.argumentsForConstructor);
    }
