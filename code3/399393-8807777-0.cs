    void TestOfT<T>(IEnumerable<T> list) where T: class, new()
    {
        var properties = typeof(T).GetProperties();
        foreach (var item in list)
        foreach (var property in properties)
        {
            var name = property.Name;
            var value = property.GetValue(item, null);
            Debug.WriteLine("{0} is {1}", name, value);
        }
    }
