    public T AddUnique(T item)
    {
        T result = Find(x => x.Name == item.Name);
        if (result.Equals(default(T)))
        {
            Add(item);
            return item;
        }
        return result;
    }
