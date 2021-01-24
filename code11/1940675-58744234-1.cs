    public static T Get<T>(int id)
    {
        string json = DoSomething(); // <-- making it easy for this post
        List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
    
        return items.FirstOrDefault(
            item => (int)item.GetType()
                             .GetProperties()
                             .FirstOrDefault(
                                p => Attribute.IsDefined(p, typeof(KeyAttribute))
                             ).GetValue(item) == id
        );
    }
