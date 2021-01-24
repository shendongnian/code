    public static bool ContainsAny(this string haystack, params string[] needles)
            {
                foreach (var needle in needles)
                {
                    if (haystack.Contains(needle))    
                        return true;
                }
    
                return false;
            }  
