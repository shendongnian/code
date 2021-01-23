 csharp
// excuse the poorly named types
public class ListDownloaderEnumerator<T> : IEnumerator<T>
{
    private int index;
    private readonly string url;
    private IReadOnlyList<T> items;
    public ListDownloaderEnumerator(string url)
    {
        this.url = url;
    }
    public bool MoveNext()
    {
        if (items == null) 
        index = index + 1;
        return index < items.Count;
    }
    public void Reset()
    {
        // downloading logic removed for brevity
        items = download(url);
    }
    // other parts of IEnumerator<T>, such as Current
}
public class SelectEnumerator<T, TResult> : IEnumerator<T>
{
    private readonly IEnumerator<T> enumerator;
    private readonly Func<T, TResult> projection;
    public SelectEnumerator(IEnumerator<T> enumerator, Func<T, TResult> projection)
    {
        this.enumerator = enumerator;
        this.projection = projection;
    }
    public bool MoveNext()
    {
        return enumerator.MoveNext();
    }
    public void Reset()
    {
        enumerator.Reset();
    }
    // other parts of IEnumerator<T>, such as Current
}
}
