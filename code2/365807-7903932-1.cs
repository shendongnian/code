    public static List<ListItem> ListItemListFromEnum(Type t)
    {
            if (!t.IsEnum)
            {
                throw new ArgumentException("The type passed in must be an enum type.");                
            }
            // ...
    }
