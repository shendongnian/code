    private static void SetCountToOneIfExists(this IEnumerable<Foo> items, int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if(item != null)
           item.Bar = 1;
    }
    
    items.SetCountToOneIfExists(1);
