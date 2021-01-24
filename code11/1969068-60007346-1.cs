public class GenericDataReader<T> : IDataReader where T : class
{
    private readonly IAsyncEnumerator<T> _asychEnumerator;
    private readonly List<FieldInfo> _fields = new List<FieldInfo>();
    public GenericDataReader(IAsyncEnumerable<T> asyncEnumerable)
    {
        _asychEnumerator = asyncEnumerable.GetAsyncEnumerator();
        foreach (FieldInfo fieldinfo in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public))
        {
            _fields.Add(fieldinfo);
        }
    }
    public int FieldCount => _fields.Count;
    public void Dispose() { Close(); }
    public bool Read()
    {
        return _asycEnumerator.MoveNextAsync().Result;
    }
    public async void Close(){ await _asychEnumerator.DisposeAsync(); }
    public Type GetFieldType(int i){ return _fields[i].FieldType; }
    public string GetName(int i) { return _fields[i].Name; }
    public object GetValue(int i){ return _fields[i].GetValue(_asychEnumerator.Current); }
}	
I'm still working through the example, but am a bit leary of the Read() method's implementation.
  [1]: https://www.codeproject.com/Articles/1095790/Using-SqlBulkCopy-with-IDataReader-for-Hi-Perf-Ins
