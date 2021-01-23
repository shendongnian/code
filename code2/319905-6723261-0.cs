     object padlock = new object
     public bool Contains(T item)
     {
        lock (padlock)
        {
            return items.Contains(item);
        }
     }
