    yourCollectionOfItems.AreItemsCompatible();
    // ...
    public static void AreItemsCompatible(this IEnumerable<MyItem> source)
    {
        using (var e = source.GetEnumerator())
        {
            var buffer = new List<MyItem>();
            while (e.MoveNext())
            {
                foreach (MyItem item in buffer)
                {
                    if (item.IsCompatibleWith(e.Current))
                    {
                        Console.WriteLine(item + " is compatible with " + e.Current);
                    }
                }
                buffer.Add(e.Current);
            }
        }
    }
