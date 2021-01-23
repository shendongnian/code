    static public class ListExt
    {
        static public List<T> StoreSize<T>(this List<T> self, out int size)
        {
            size = (self != null) ? self.Count : -1;
            return self;
        }
    }
    ...
    List<int> even = Load().StoreSize(out count).FindAll(x => (x % 2) == 0);
