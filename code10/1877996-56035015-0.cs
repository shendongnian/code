    public static T ArgMin<T, R>(T t1, T t2, Func<T, R> f)
                    where R : IComparable<R>
    {
        return f(t1).CompareTo(f(t2)) > 0 ? t2 : t1;
    }
    public static T ArgMin<T, R>(this IEnumerable<T> Sequence, Func<T, R> f)
                    where R : IComparable<R>
    {
        return Sequence.Aggregate((t1, t2) => ArgMin<T, R>(t1, t2, f));
    }
    var iNow = DateTime.Now;
    var iResult = times.ArgMin(iTime => Math.Abs((iTime - iNow).Ticks));
