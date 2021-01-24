    using (db = new LinqToSqlDataContext(conStr))
    {
        var contacts = db.Contacts.ToList(); // <-- converts the result to List
        return View(contacts);
    }
