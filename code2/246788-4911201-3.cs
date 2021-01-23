    public static TResult DoSomething<TType, TResult>(this TType @class)
        {
            // access static methods with System.Reflection
            return default(TResult);
        }
    
    // This works, but poorly
    typeof(Math).DoSomething();
    typeof(Convert).DoSomething();
