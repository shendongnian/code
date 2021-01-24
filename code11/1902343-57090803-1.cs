    public class MyVirtualCollection<T> : ICollection<T> where T : Entity
    {
        ICollection<T> Items { get; set; }
        
        private void Suscribe(Entity entity)
        { 
            Items.Remove(entity);
        }
        public MyVirtualCollection(ICollection<T> source)
        {
            Items = source;
            foreach(var ent in Items)
            {
                ent.OnEntityDeleted += Suscribe;
            }
        }
        public int Count => Items.Count;
    
        public bool IsReadOnly => Items.IsReadOnly;
    
        public void Add(T item)
        {
            Items.Add(item);
            item.OnEntityDeleted += Suscribe;
        }
    
        public void Clear()
        {
            foreach(var ent in Items)
            {
                ent.OnEntityDeleted -= Suscribe;
            }
            Items.Clear();
        }
    
        public bool Contains(T item)
        {
            return Items.Contains(item);
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    
        public bool Remove(T item)
        {
            item.OnEntityDeleted -= Suscribe;
            return Items.Remove(item);
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
