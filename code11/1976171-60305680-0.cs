    public static IEnumerable<T> ReplaceWhile<T>(IEnumerable<T> source, Func<T, bool> predicate, T subsitute)
    {
    	var matching = true;
    	foreach(var item in source)
    		yield return !matching ? item : (matching = predicate(item)) ? subsitute : item;
    }
