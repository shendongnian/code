    var query = from msg in context.Email
                join contact in context.Contact 
                     on msg.SenderEmail equals contact.Email
                     into contacts
                select new { msg, contacts };
    var list = query.ToList();
    foreach (var pair in list)
    {
        pair.msg.Sender = pair.contacts.FirstOrDefault();
    }
    var messages = list.Select(pair => pair.msg);
