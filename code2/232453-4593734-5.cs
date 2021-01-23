    var mappings = new Dictionary<string,string>();
    mappings.Add("ItemId", "item_id");
    mappings.Add("ItemName ", "item_name");
    mappings.Add("Price ", "price);
    var items = dt.ToList<Item>(mappings);
