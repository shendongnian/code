With this solution you'd have access to the individual indexes that matched (while enumerating) or you could call Count() on the result to see how many matches there were:
public static IEnumerable&lt;int&gt; Find&lt;T&gt;(T[] pattern, T[] sequence, bool overlap)
{
    int i = 0;
    while (i &lt; sequence.Length)
    {
        if (pattern.SequenceEqual(sequence.Skip(i).Take(pattern.Length)))
        {
            yield return i;
            i += overlap ? 1 : pattern.Length;
        }
        else
        {
            i++;
        }
    }
}
Call it with overlap: false to solve your problem or overlap: true to see the overlapped matches (if you're interested.)
