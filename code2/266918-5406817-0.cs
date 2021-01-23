    public static bool IsValid(T obj, Predicate<T> condition)
    {
            return condition(obj);
    }
    
    Validator.IsValue(foo,f=>f.Value==1);
