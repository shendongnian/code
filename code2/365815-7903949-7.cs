    public static List<ListItem> ListItemListFromEnum<T>()
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("Type must be an enumeration", "t");
        }     
    }
