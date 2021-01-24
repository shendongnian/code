 c#
// when field 2
var val = obj.OffsetDictionary;
bool setValue = false;
if (val == null)
{
    val = new SortedDictionary<short, SortedDictionary<short, uint>>();
    setValue = true;
}
do {
    val.Add(/* parse this entry */);
} while (/* still field 2 */)
if (setValue) obj.OffsetDictionary = val;
Although not that assigning *at the start* (where `setValue` is assigned) would also be legitimate.
As it happens, you can *sort of* make this work by using
 c#
[ProtoMember(2, OverwriteList = true)]
but... it works for the wrong reasons IMO, as that could also be interpreted as working identically, but just adding a `.Clear()`, which wouldn't change the output.
Frankly, I'm not sure that I really like the overall design here; personally, I'd keep the data *in the form you're going to serialize*, and add utility methods on `Test` that do the flip, i.e.
 c#
[ProtoContract]
public class Test
{
    [ProtoMember(1)]
    public DateTime BaseDate { get; set; }
    [ProtoMember(2)]
    public SortedDictionary<short, SortedDictionary<short, uint>> OffsetDictionary { get; }
        = new SortedDictionary<short, SortedDictionary<short, uint>>();
    private short ToInt16(DateTime value) => (short)(value - BaseDate).TotalDays;
    public void Add(DateTime key, SortedDictionary<short, uint> value)
        => OffsetDictionary.Add(ToInt16(key), value);
    public bool TryGetValue(DateTime key, out SortedDictionary<short, uint> value)
        => OffsetDictionary.TryGetValue(ToInt16(key), out value);
}
However, you could also do this using a wrapper layer - although it is much more work:
 c#
[ProtoContract]
public class Test
{
    [ProtoMember(1)]
    public DateTime BaseDate { get; set; }
    private DictionaryWrapper _offsetDictionary;
    [ProtoMember(2)]
    public IDictionary<short, SortedDictionary<short, uint>> OffsetDictionary
        => _offsetDictionary ?? (_offsetDictionary = new DictionaryWrapper(this));
    public SortedDictionary<DateTime, SortedDictionary<short, uint>> Dictionary { get; }
        = new SortedDictionary<DateTime, SortedDictionary<short, uint>>();
    class DictionaryWrapper : IDictionary<short, SortedDictionary<short, uint>>
    {
        public DictionaryWrapper(Test parent)
        {
            _parent = parent;
        }
        private readonly Test _parent;
        private DateTime ToDateTime(short value) => _parent.BaseDate.AddDays(value);
        private short ToInt16(DateTime value) => (short)(value - _parent.BaseDate).TotalDays;
        SortedDictionary<short, uint> IDictionary<short, SortedDictionary<short, uint>>.this[short key]
        {
            get => _parent.Dictionary[ToDateTime(key)];
            set => _parent.Dictionary[ToDateTime(key)] = value;
        }
        int ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.Count => _parent.Dictionary.Count;
        bool ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.IsReadOnly => false;
        void IDictionary<short, SortedDictionary<short, uint>>.Add(short key, SortedDictionary<short, uint> value)
            => _parent.Dictionary.Add(ToDateTime(key), value);
        void ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.Add(KeyValuePair<short, SortedDictionary<short, uint>> item)
            => _parent.Dictionary.Add(ToDateTime(item.Key), item.Value);
        void ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.Clear()
            => _parent.Dictionary.Clear();
        private ICollection<KeyValuePair<DateTime, SortedDictionary<short, uint>>> AsCollection => _parent.Dictionary;
        bool ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.Contains(KeyValuePair<short, SortedDictionary<short, uint>> item)
            => AsCollection.Contains(new KeyValuePair<DateTime, SortedDictionary<short, uint>>(ToDateTime(item.Key), item.Value));
        bool IDictionary<short, SortedDictionary<short, uint>>.ContainsKey(short key)
            => _parent.Dictionary.ContainsKey(ToDateTime(key));
        private IEnumerator<KeyValuePair<short, SortedDictionary<short, uint>>> GetEnumerator()
        {
            foreach (var item in _parent.Dictionary)
                yield return new KeyValuePair<short, SortedDictionary<short, uint>>(ToInt16(item.Key), item.Value);
        }
        IEnumerator<KeyValuePair<short, SortedDictionary<short, uint>>> IEnumerable<KeyValuePair<short, SortedDictionary<short, uint>>>.GetEnumerator()
            => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        bool IDictionary<short, SortedDictionary<short, uint>>.Remove(short key)
            => _parent.Dictionary.Remove(ToDateTime(key));
        bool ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.Remove(KeyValuePair<short, SortedDictionary<short, uint>> item)
            => AsCollection.Remove(new KeyValuePair<DateTime, SortedDictionary<short, uint>>(ToDateTime(item.Key), item.Value));
        bool IDictionary<short, SortedDictionary<short, uint>>.TryGetValue(short key, out SortedDictionary<short, uint> value)
            => _parent.Dictionary.TryGetValue(ToDateTime(key), out value);
        // these are kinda awkward to implement
        ICollection<short> IDictionary<short, SortedDictionary<short, uint>>.Keys
            => throw new NotSupportedException();
        ICollection<SortedDictionary<short, uint>> IDictionary<short, SortedDictionary<short, uint>>.Values
            => throw new NotSupportedException();
        void ICollection<KeyValuePair<short, SortedDictionary<short, uint>>>.CopyTo(KeyValuePair<short, SortedDictionary<short, uint>>[] array, int arrayIndex)
            => throw new NotSupportedException();
    }
}
