    public static void RemoveWhere<T>(this ICollection<T> self, Func<T, bool> predicate)
    {
        var toRemove = self.Where(predicate).ToList();
        foreach (var i in toRemove)
            self.Remove(i);
    }
