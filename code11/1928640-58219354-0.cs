var lists=Enumerable.Range(0,17);
var batches=Batch(lists,5);
foreach(var batch in batches)
{
   Console.WriteLine(String.Join(" - ",batch));
}
This produces :
0 - 1 - 2 - 3 - 4
5 - 6 - 7 - 8 - 9
10 - 11 - 12 - 13 - 14
15 - 16
This is far faster than grouping as it only iterates the collection once.
The operator's implementation is simple enough that you can just copy it into your project:
    public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
    {
        return Batch(source, size, x => x);
    }
    public static IEnumerable<TResult> Batch<TSource, TResult>( IEnumerable<TSource> source, int size,
        Func<IEnumerable<TSource>, TResult> resultSelector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
    
        return _(); IEnumerable<TResult> _()
        {
            TSource[] bucket = null;
            var count = 0;
    
            foreach (var item in source)
            {
                if (bucket == null)
                {
                    bucket = new TSource[size];
                }
    
                bucket[count++] = item;
    
                // The bucket is fully buffered before it's yielded
                if (count != size)
                {
                    continue;
                }
    
                yield return resultSelector(bucket);
    
                bucket = null;
                count = 0;
            }
    
            // Return the last bucket with all remaining elements
            if (bucket != null && count > 0)
            {
                Array.Resize(ref bucket, count);
                yield return resultSelector(bucket);
            }
        }
    }
