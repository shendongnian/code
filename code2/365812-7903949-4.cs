    public static List<ListItem> ListItemListFromEnum(Type t)
    {
        if (!t.IsEnum)
        {
            throw new ArgumentException("Type must be an enumeration", "t");
        }     
    }
