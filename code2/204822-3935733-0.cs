    var list = allContacts
                 .Select(c => new { c.ContactID, c.FullName })
                 .ToList();
    foreach (var o in list) {
        Console.WriteLine(o.ContactID);
    }
