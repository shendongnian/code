    public class C {
        public void Query(IThing<string> thing) {
            var y = from x in thing
                select x;
        }
    }
    public interface IThing<T>
    {
        T Foo { get; }   
    }
    public static class ThingExtensions
    {
        public static IThing<T> Select<T>(this IThing<T> thing, Func<IThing<T>, IThing<T>> selector)
        {
            return selector(thing);
        }
    }
