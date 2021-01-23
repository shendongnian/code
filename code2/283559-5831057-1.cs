    public static void ForEach(this ListItemCollection collection, Action<ListItem> act )
    {
        foreach (ListItem item in collection)
        {
            act(item);
            if(condition) break;
        }
    }
