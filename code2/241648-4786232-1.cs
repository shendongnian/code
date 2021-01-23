    var query = (from item in context.Items
        select new Item {                     
            Title = item.Title
        });
    var ret = query.AsEnumerable().Select(i => {
        // Set the count.
        i.Count = 1;
        // Return the item.
        return i;
    });
