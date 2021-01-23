        var qry = from email in context.Email
                  join contact in context.Contact 
                  on email.SenderEmail equals contact.Email
                  into contacts
                  select new { eml = email, sender = contacts.FirstOrDefault() };
        var items = qry.ToList();
        foreach (var item in items)
        {
            item.eml.Sender = item.sender;
            outputList.Add(item.eml);
        }
        return outputList;
