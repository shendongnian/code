    public IList<Item> GetAllProducts()
    {
         var query = from item in DataContext.Items
                     where item.Quantity > 0
                     orderby item.LastUpdated descending
                     select item;
         return query.AsEnumerable()
                     .Where(s => HelperClass.IsLastUpdate(s.LastUpdated.Value))
                     .ToList();
    }
