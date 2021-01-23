    using (var e = myItems.GetEnumerator())
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
