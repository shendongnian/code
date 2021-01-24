    using (var context = new YourDbContextHere())
    {
        var dateRetrieved = DateTime.Now;
        var items = context.Items.Where(x => x.Id == Id)
           .Select(x => new ItemList
           {
               ItemId= item.Id,
               Name = item.Name,
               Color = item.Feature.Color,
               DateReteived = dateRetrieved
           }).ToList();
        return items;
    }
