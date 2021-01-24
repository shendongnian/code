    public async Task<List<T>> Handler<T>(List<Item> items) where T: MyInterface, new()
    {
        var newList= new List<T>();
        foreach (var item in items)
        {
            newList.Add(new T
            {
                ID = item.ID,
                Name = item.Status,
                Retrieved = DateTime,
            });
        }
        // ...
    }
