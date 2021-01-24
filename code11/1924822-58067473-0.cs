`
(x, i) => new { Index = i, Item = x }
`
Like Linq
`
public static IEnumerable<List<T>> splitList<T>(List<T> items, int size)  
{        
    for (int i=0; i < items.Count; i+= size) 
    { 
        yield return items.GetRange(i, Math.Min(size, items.Count - i)); 
    }  
}
`
OR better performance
`
public static List<List<T>> Split<T>(this List<T> items, int size)
{
    List<List<T>> list = new List<List<T>>();
    for (int i = 0; i < items.Count; i += size)
        list.Add(items.GetRange(i, Math.Min(size, items.Count - i)));
    return list;
}
` 
