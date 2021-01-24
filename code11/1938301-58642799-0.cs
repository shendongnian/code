    private static void SetCountToOneIfExists(this IEnumerable<Foo> items, int Id)
    {
        var item = items.FirstOrDefault(i => i.Id == 1);
        if(item != null)
           item.Bar = 1;
    }
    
    items.SetCountToOneIfExists(1);
