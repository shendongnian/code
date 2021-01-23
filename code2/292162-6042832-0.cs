     public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
     {
         if (action == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        
    	foreach(T item in enumeration)
        {
            action(item);
        }
     }
