    bool compatible = myItems.AreAllItemsCompatible();
    // ...
    public static bool AreAllItemsCompatible(this IEnumerable<MyItem> source)
    {
        using (var e = source.GetEnumerator())
        {
            var buffer = new List<MyItem>();
            while (e.MoveNext())
            {
                foreach (MyItem item in buffer)
                {
                    if (!item.IsCompatibleWith(e.Current))
                        return false;
                }
                buffer.Add(e.Current);
            }
        }
        return true;
    }
