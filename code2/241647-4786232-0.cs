    var query = (from item in contex.Items
        select new Itemm {                     
            Title = item.Title
        });
    var ret = query.AsEnumerable().Select(i => {
        // Set the count.
        i.Count = 1;
        // Return the item.
        return i;
    });
