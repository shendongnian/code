    public static bool CountIsEqualTo<T>(this IEnumerable<T> enumerable, int c) 
    {
        using (var enumerator = enumerable.GetEnumerator()) 
        {
            for(var i = 0; i < c ; i++)
                if (!enumerator.MoveNext()) 
                    return false;
            
            return !enumerator.MoveNext();
        }
    }
