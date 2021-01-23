    class DataItem
    {
        public int Data { get; set; }
        public bool IsDirty { get; set; }
    }
    var data = new ConcurrentDictionary<string, DataItem>();
    Thread addingItems = new Thread(() =>
        {
           for (int i = 0; i < 10000; i++)
           {
               data.TryAdd("data " + i, new DataItem { Data = i, IsDirty = true });
               Thread.Sleep(100);
           }
        });
    Thread fetchingItems = new Thread(() =>
        {
            int count = 0;
            while (count < 100)
            {
                foreach (var item in data)
                {
                    if (item.Value.IsDirty)
                    {
                        Console.WriteLine(item.Key + " " + item.Value);
                        item.Value.IsDirty = false;
                        count++;
                    }
                }
            }
        });
    addingItems.Start();
    fetchingItems.Start();
