    public interface IKey
    {
        Type GetKeyType();
        V GetValue<V>();
    }
    public class Key<T, V> : IKey
    {
        public V ID { get; set; }
        public Key(V id)
        {
            ID = id;
        }
        public Type GetKeyType()
        {
            return typeof(T);
        }
        public Tp GetValue<Tp>()
        {
            return (Tp)(object)ID;
        }
    }
    public class Triple<T, V, Z>
    {
        public T First { get; set; }
        public V Second { get; set; }
        public Z Third { get; set; }
        public Triple(T first, V second, Z third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
