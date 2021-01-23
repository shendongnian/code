    public static class ListExtensions
    {   
        public static TC AddItem<TC, T>(this TC self, T item)
            where TC : ICollection<T>
        {
            self.Add(item);
            return self;
        }
    }
    var c1 = new Collection<int>();
    c1.AddItem(1).AddItem(2);
    var c2 = new List<int>();
    c2.AddItem(10).AddItem(20);
