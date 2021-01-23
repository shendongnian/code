    public void LogEmployees<T>(IEnumerable<T> list)
    {
        foreach (T item in list)
        {
            var typedItem = Cast(item, new { Name = "", Id = 0 });
            // now you can use typedItem.Name, etc.
        }
    }
    static T Cast<T>(object obj, T type)
    {
        return (T)obj;
    }
