    public static Dictionary<int, string> EnumToDictionary<TK>(Func<TK, string> func)
    {
         if (typeof(TK).BaseType != typeof(Enum))
            throw new InvalidOperationException("Type must be enum");
         return Enum.GetValues(typeof(TK)).Cast<TK>().ToDictionary(x => Convert.ToInt32(x), x => func(x));
    }
    
