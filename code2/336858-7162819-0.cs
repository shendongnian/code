    public interface IData<TData>
    {
        IEnumerable<TData> Values { get; }
    }
    public class Data<TData, TKey> : IData<TData>
    {
        private Dictionary<TKey, List<TData>> keyedData;
        public delegate TKey Key(TData row);
        public Data(IData<TData> data, Key keyDelegate, string keyName)
                : this(data.Values, keyDelegate, keyName)
        {
            //...
        }
    }
