    public static class Extensions  
    {  
        public static void Add<T>(this IList<T> source, SomeParameter value) 
            where T : IField, new()  
        {  
        }  
    } 
