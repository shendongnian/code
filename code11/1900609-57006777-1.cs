    public static bool DeepEquals(object a, object b)
    {
        if (a == null)
        {
            if (b == null) return true;
            else return false;
        }
        else if (b == null) return false;
    
        if (object.ReferenceEquals(a, b)) return true;
    
        var comparable = a as IComparable;
        if (comparable != null)
        {
            return comparable.CompareTo(b) == 0;
        }
    
        var aType = a.GetType();
        var bType = b.GetType();
        if (aType != bType) return false;
    
        var aEnumerable = a as IEnumerable;
        if (aEnumerable != null)
        {
            var bEnumerable = (IEnumerable)b;
            var aEnumerator = aEnumerable.GetEnumerator();
            var bEnumerator = bEnumerable.GetEnumerator();
            while (true)
            {
                var amoved = aEnumerator.MoveNext();
                var bmoved = bEnumerator.MoveNext();
                if (amoved != bmoved) return false;
                if (amoved == false && bmoved == false) return true;
                if (DeepEquals(aEnumerator.Current, bEnumerator.Current) == false) return false;
            }
        }
    
        var props = aType.GetProperties();
        foreach (var prop in props)
        {
            if (DeepEquals(prop.GetValue(a), prop.GetValue(b)) == false) return false;
        }
        return true;
    }
