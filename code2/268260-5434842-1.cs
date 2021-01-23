    public abstract class Base<TFirst, TSecond>
        where TFirst : First
    {
        static Base()
        {
            if(!typeof(TFirst).IsGenericType || 
                typeof(TFirst).GetGenericTypeDefinition() != typeof(First<,>))
                throw new ArgumentException("TFirst");
        }
    }
    public abstract class First { }
    public abstract class First<TFirstID, TFirstData> : First
    {
    }
