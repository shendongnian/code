    public interface ILookup<K, V>
    {
        V this[K key] { get; }
    }
    public class DictWrapper<K, V> : ILookup<K, V>
    {
        Dictionary<K, V> dictionary;
        public DictWrapper(Dictionary<K, V> dictionary)
        {
            this.dictionary = dictionary;
        }
        public V this[K key]
        {
            get { return dictionary[key]; }
        }
        protected internal Dictionary<K, V> InnerDictionary { get { return dictionary; } }
    }
    public static class Extensions
    {
        public static ILookup<K, V> ToLookup<K, V>(this Dictionary<K, V> dictionary)
        {
            return new DictWrapper<K, V>(dictionary);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("Office", 100);
            data.Add("Walls", 101);
            data.Add("Stair", 30);
            ILookup<string, int> look = data.ToLookup();
        }
    }
