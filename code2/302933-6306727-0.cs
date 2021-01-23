    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<U> uList = new List<U>();
            IEnumerable<V> vList1 = uList.To(u => new V(u)); //Option 1 : explicit transformation, needs neither any interface nor explicit types (type inference at work)
            IEnumerable<V> vList2 = uList.To<U, V>(); //Option 2 : implicit transformation internally supported from U to V by type V thanks to IBuildableFrom<TV, TU>, but you must precise To<U, V>() with the types
        }
    }
    public static class Extensions    {
        //Option 1
        public static IEnumerable<TV> To<TU, TV>(this IEnumerable<TU> source, Func<TU,TV> transform)
        {
            return source.Select(tu => transform(tu));
        }
        //Option 2
        public static IEnumerable<TV> To<TU, TV>(this IEnumerable<TU> source) where TV : IBuildableFrom<TV, TU>, new()
        {
            return source.Select(tu => new TV().BuildFrom(tu));
        }
    }
    public interface IBuildableFrom<TV, TU>
    {
        TV BuildFrom(TU tu);
    }
    public class U { } //Cheesy concrete class playing the rôle of TU
    public class V : IBuildableFrom<V, U> //Cheesy concrete class playing the rôle of TV
    {
        public V BuildFrom(U u)
        {
            //Initialization of this' properties based on u's ones
            return this;
        }
        public V(U u) { }//Used by option 1
        public V() { } //Used by option 2
    }
