    using (var ctx = new DataContext())
    {
        ctx.Users.Attach(existingUser);
        // create item and add to context
        var newItem = new MyItem();
        // set related entity
        newItem.CreatedBy = existingUser;
        ctx.MyItems.Add(newItem);
        ctx.SaveChanges();
    }
