    public static class ListExtensions
    {
        public static List<T> AddItem<T>(this List<T> self, T item)
        {
            self.Add(item);
            return self;
        }
    }
    var l = new List<int>();
    l.AddItem(1).AddItem(2);
