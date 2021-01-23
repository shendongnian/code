    public static Tuple<T1,T2> Append(this Tuple<T1> tuple, T2 addend)
    {
       return Tuple.Create(tuple.Item1, addend);
    }
    
    public static Tuple<T1,T2, T3> Append(this Tuple<T1,T2> tuple, T3 addend)
    {
       return Tuple.Create(tuple.Item1, tuple.Item2, addend);
    }
    
    ...
