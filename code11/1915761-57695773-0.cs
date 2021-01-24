    public static bool? AllOrNothing(this IEnumerable<bool> list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        using(var enumerator = list.GetEnumerator())
        {
            if (!enumerator.MoveNext()) 
                return null; // or true or false, what you need for an empty list
            
            bool? current = enumerator.Current;
            while(enumerator.MoveNext())
                if (current != enumerator.Current) return null;
            return current;
        }
    }
