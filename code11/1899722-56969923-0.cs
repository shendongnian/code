    public static IEnumerable<Item> EnumerateItems(this List list, int rowLimit, List<string> fields, bool includeRoleAssignments, ILogger logger)
    {
        // ...
        do
        {
            try
            {
                using (var clonedCtx = ctx.Clone(ctx.Url))
                {
                    //...
                    camlQuery.ListItemCollectionPosition = position;
                    listItems = listWithClonedContext.GetItems(camlQuery);
                    // ...
                    foreach(Item x in listItems)
                    {
                        yield return x;
                    }
                    position = listItems.ListItemCollectionPosition;
                    // ...
        }
        while (position != null);
    }
