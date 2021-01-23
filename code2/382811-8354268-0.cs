    public class Foo
    {
        public void Bar()
        {
            int[] idOrder = new int[] { 3, 2, 20, 1 };
            var lookup = idOrder.ToDictionary(i => i,
                i => Array.IndexOf(idOrder, i));
            foreach(var a in idOrder.OrderBy(i => new ByArrayComparable<int>(lookup, i)))
                Console.WriteLine(a);
        }
    }
    public class ByArrayComparable<T> : IComparable<ByArrayComparable<T>> where T : IComparable<T>
    {
        public readonly IDictionary<T, int> order;
        public readonly T element;
        public ByArrayComparable(IDictionary<T, int> order, T element)
        {
            this.order = order;
            this.element = element;
        }
        public int CompareTo(ByArrayComparable<T> other)
        {
            return this.order[this.element].CompareTo(this.order[other.element]);
        }
    }
