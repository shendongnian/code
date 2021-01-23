    public DropDownItemCollection TestCollection
    {
        var collection = new DropDownItemCollection();
        var instance = new TestClass();
        foreach (var prop in typeof(TestClass).GetProperties())
        {
            if (prop.CanRead)
            {
                var value = prop.GetValue(instance, null) as string;
                var item = new DropDownItem();
                item.Description = value;
                item.Value = value;
                collection.Add(item);
            }
        }
        return collection;
    }
