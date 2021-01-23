    var items = new List<T>();
    var itemsToBeRemoved = new List<T>();
    foreach (T item in items) {
        if(<condition>) {  
             itemsToBeRemoved.Add(item);
        }
    }
    items.RemoveRange(itemsToBeRemoved);
