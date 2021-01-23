    public interface IAccessor<K,V> {
        V this[K key] { get; }
    }
    public interface IAttributeDictionary<K,V> : IAccessor<K,V>, IDictionary<K,V> {
        // This interface just composes the other two.
    }
    public class Test<K,V> : IAttributeDictionary<K,V> {
        // This will implement the indexer for both IAccessor and IDictionary.
        // But when the object is accessed as an IAccessor the setter is not available.
        public V this[K key] {
            get { Console.WriteLine("getter"); return default(V); }
            set { Console.WriteLine("setter"); }
        }
        
        // ...the rest of IDictionary goes here...
    }
    class Program {
        static void Main (string[] args) {
            // Note that test can be accessed as any of the appropriate types,
            // and the same getter is called.
            Test<string,int> test = new Test<string, int>();
            int a = test["a"];
            int b = ((IDictionary<string, int>)test)["b"];
            int c = ((IAccessor<string, int>)test)["c"];
        }
    }
