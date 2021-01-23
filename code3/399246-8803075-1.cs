    using System.Linq;
    ....
    public static bool ContainsAllItems(List<T> a, List<T> b)
    {
        return !b.Except(a).Any();
    }
