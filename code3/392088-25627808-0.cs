    var db = new MeatRequestDataContext();
    if (input.UserID > 0)
    {
        var existing = db.Users
            .Single(user => user.UserID == input.UserID);
        db.Users.DeleteOnSubmit(existing);
    }
