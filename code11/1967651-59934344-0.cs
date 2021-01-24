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
