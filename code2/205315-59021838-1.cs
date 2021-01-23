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
        // downloading logic removed for brevity
        if (items == null) download(url);
        index = index + 1;
        return index < items.Count;
    }
    public void Reset()
    {
        index = 0;
        items = null;
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
// somewhere else in the application
// we can now write processing code without concern for sourcing
// and perhaps projecting the data. this example is very simple,
// but using decorator enumerator you can accomplish very complex
// processing of sequences while maintaining small, testable, and
// composable classes. it also allows for highly configurable
// processing, since the decorators become building blocks.
public class DownloadedDataProcessor
{
    private readonly IEnumerator<MyProjectedListItem> enumerator;
    public DownloadedDataProcessor(IEnumerator<MyProjectedListItem> enumerator)
    {
        this.enumerator = enumerator;
    }
    public void ProcessForever()
    {
        while (true)
        {
            while (enumerator.MoveNext())
            {
                Process(enumerator.Current);
            }
            enumerator.Reset();
        }
    }
    private void Process(MyProjectedListItem item)
    {
        // top secret processing
    }
}
