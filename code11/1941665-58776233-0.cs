c#
public Metadata Meta
{
    get { return new Metadata(GetSubarray(0, 2)); }
    set { UpdateData(0, value.GetData()); }
}
The fact that you're creating a new `Metadata` object makes this statement not do what you think it's doing:
    dataObj.Meta.Prop0 = 8;
The `Meta` property getter is creating a new `Meta` object, which is then used to set the `Prop0` property. But this `Meta` object has no connection to the `DataObject` object. The object's `Prop0` setter is called, and then that `Meta` object is immediately forgotten about. There is no reference to it, it will eventually be collected by the garbage collector, and it has no effect on the `DataObject` object.
Given your current `DataObject` implementation, one way to fix the code would be to retrieve the `Meta` object into a variable, set the `Prop0` property, and then set the `Meta` property again:
c#
Meta meta = dataObj.Meta;
meta.Prop0 = 8;
dataObj.Meta = meta;
Now, frankly I think that this overall design is just plain broken. The idea of storing these values in an array, and then trying to map array elements to individual properties, it's just asking for trouble. It will lead to exactly the kind of bug you have here, and makes it very difficult to understand and use the objects. If you _do_ really want to use an array to back the properties, then you really should at least make sure that you only ever allocate the array and objects once, so that to the caller, the properties act like normal properties instead of having this weird "you have to save the object, modify it, and then set the property value again" semantics. For example, something like this:
c#
public class DataObject
{
    private struct ByteSpan : IList<byte>
    {
        private readonly byte[] _data;
        private readonly int _start;
        private readonly int _count;
        public ByteSpan(byte[] data, int start, int count)
        {
            _data = data;
            _start = start;
            _count = count;
        }
        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
                return _data[_start + index];
            }
            set
            {
                if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
                _data[_start + index] = value;
            }
        }
        public int Count => _count;
        public bool IsReadOnly => false;
        public void Add(byte item) => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public bool Contains(byte item) => this.Any(b => b == item);
        public void CopyTo(byte[] array, int arrayIndex) => Array.Copy(_data, _start, array, arrayIndex, _count);
        public IEnumerator<byte> GetEnumerator() => _data.Skip(_start).Take(_count).GetEnumerator();
        public int IndexOf(byte item)
        {
            int indexOf = ((IList<byte>)_data).IndexOf(item) - _start;
            if (indexOf < 0) return -1;
            if (indexOf >= _count) return -1;
            return indexOf;
        }
        public void Insert(int index, byte item) => throw new NotImplementedException();
        public bool Remove(byte item) => throw new NotImplementedException();
        public void RemoveAt(int index) => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    private readonly byte[] _data;
    private readonly IList<byte> _property1;
    public DataObject(byte[] objectData)
    {
        _data = objectData;
        Meta = new Metadata(new ByteSpan(_data, 0, 2));
        _property1 = new ByteSpan(_data, 2, 5);
    }
    public byte[] GetData()
    {
        return _data;
    }
    public Metadata Meta { get; }
    public IList<byte> Property1
    {
        get => _property1;
        set => CopyIList(value, _property1);
    }
    private void CopyIList<T>(IList<T> source, IList<T> destination)
    {
        if (source.Count != destination.Count) throw new ArgumentException("source and destination must be the same length");
        for (int i = 0; i < source.Count; i++)
        {
            destination[i] = source[i];
        }
    }
}
public class Metadata
{
    private IList<byte> _metadata;
    public Metadata(IList<byte> metadata)
    {
        _metadata = metadata;
    }
    public IList<byte> GetData()
    {
        return _metadata;
    }
    public byte Prop0
    {
        get => _metadata[0];
        set => _metadata[0] = value;
    }
    public byte Prop1
    {
        get => _metadata[1];
        set => _metadata[1] = value;
    }
}
To do the above, it is necessary to modify the `DataObject` interface a little. Specifically, instead of returning arrays, it has to return `IList<T>` objects. This allows the same array to be used as the underlying storage for all of the array-like properties that are exposed.
_(Aside: the above uses a custom `ByteSpan` type that implements the `IList<T>` that represents the subset of the underlying data array. If you can use .NET Core, you'll find the equivalent `Span<T>` struct which can be used instead.)_
If you insist on returning array values instead of `IList<byte>`, then you will have to modify the above slightly so that the property setters _copy_ the values from the provided array into the underlying data array. Likewise, the getters will have to copy the values out. Unfortunately, this will lead to something very similar to what you're already dealing with, which is that the array being returned by the property cannot directly modify the underlying data array. If the caller only retrieves the array value and modifies that without setting the property again to that same array, the underlying data array won't be modified, and you'll have the same exact problem.
Even with the above version, where the properties use `IList<byte>` instead of `byte[]`, the setter still needs to copy the given list to the property's own list, because the list being passed to the setter may or may not be the original one. If it's not, then assigning the property's list reference to that would disconnect the property from the underlying storage. Only by copying the values from one to the other instead, can the property's list remain the same, and continue to reference the original underlying data array.
But at least by using `IList<byte>` instead of `byte[]`, the caller isn't _required_ to set the property value again after modifying the list. Modifying the list will in and of itself modify the underlying data array.
I strongly recommend against using a data array as the underlying storage, but if you do, I just as strongly recommend that you _do_ use something like the `ByteSpan` or `Span<T>` types to wrap the underlying data array in an object that callers can manipulate while directly affecting the underlying storage.
