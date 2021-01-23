<pre>
private Dictionary < T, object > dictionary = null;
public static bool ContainsField<T>(this IEnumerable<T> array, string fieldname, object obj)
    {
        if (dictionary == null) // first call, build dictionary
        {
            dictionary = new Dictionary < T, object > ();
            foreach(T val in array)
                dictionary[val.GetType().GetField(fieldname).GetValue(val)] = val;
         }
         return dictionary.ContainsKey(obj); // every other call use dictionary
    }
</pre>
