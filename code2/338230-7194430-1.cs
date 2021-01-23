    Contacts = db.Contacts.Join(
        db.Contact_tls.Where(i => i.Culture == "fr"),
        i => i.ID,
        t => t.ID,
        (i, t) => new { ID = i.ID, Name = t.Name, Text = t.Text })
        .AsEnumerable()
        .Select(x =>  new Contact { ID = x.ID, Name = x.Name, Text = x.Text })
        .ToList();
