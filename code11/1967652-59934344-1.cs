cs
var castedThis = (IEnumerable<U>)Convert.ChangeType(Parameter, enumerableType);
where `T` is `IEnumerable<U>` and `U` is dynamic.
I don't think you can do that.
If you are happy with some boxing though, you can use the non-generic `IEnumerable` interface:
cs
public bool Equals(MyClass<T> other)
{
    var parameterType = typeof(T);
    if (typeof(IEnumerable).IsAssignableFrom(parameterType))
    {
        var castedThis = ((IEnumerable)this.Parameter).GetEnumerator();
        var castedOther = ((IEnumerable)other.Parameter).GetEnumerator();
        try
        {
            while (castedThis.MoveNext())
            {
                if (!castedOther.MoveNext())
                    return false;
                if (!Convert.Equals(castedThis.Current, castedOther.Current))
                    return false;
            }
            return !castedOther.MoveNext();
        }
        finally
        {
            (castedThis as IDisposable)?.Dispose();
            (castedOther as IDisposable)?.Dispose();
        }
    }
    else
    {
        return EqualityComparer<T>.Default.Equals(this.Parameter, other.Parameter);
    }
}
If you are not happy with the boxing, then you can use reflection to construct and call `SequenceEqual` (as inspired by https://stackoverflow.com/q/1452261/11683):
cs
public bool Equals(MyClass<T> other)
{
    var parameterType = typeof(T);
    if (typeof(IEnumerable).IsAssignableFrom(parameterType))
    {
        var enumerableType = parameterType.GetGenericArguments().First();
        var sequenceEqualMethod = typeof(Enumerable)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(mi => {
                if (mi.Name != "SequenceEqual")
                    return false;
                if (mi.GetGenericArguments().Length != 1)
                    return false;
                var pars = mi.GetParameters();
                if (pars.Length != 2)
                    return false;
                return pars[0].ParameterType.IsGenericType && pars[0].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>) && pars[1].ParameterType.IsGenericType && pars[1].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>);
            })
            .First()
            .MakeGenericMethod(enumerableType)
        ;
        return (bool)sequenceEqualMethod.Invoke(this.Parameter, new object[] { this.Parameter, other.Parameter });
    }
    else
    {
        return EqualityComparer<T>.Default.Equals(this.Parameter, other.Parameter);
    }
}
You can cache the `sequenceEqualMethod` for better performance.
