    public int GetIndex<T>(IEnumerable<T> list, T item, int itemNum) {
        // result is a nullable int containing the index
        var result = list.Select((x, i) => new { x, i })
                         .Where(t => item.Equals(t.x))
                         .Skip(itemNum - 1)
                         .Select(t => (int?)t.i)
                         .FirstOrDefault();
        // return -1 when item was not found
        return (result.HasValue ? result.Value : -1);
    }
