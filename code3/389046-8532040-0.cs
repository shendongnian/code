    IQueryable<Contacts> query = (from c in _ctx.Contacts select c);
    ...
    query = query.Where(x=> x.Name.ToLower().Contains(nameStr.ToLower());
    ...
    IQueryable<ContactOperationPlaces> query_2 =
         (from c in _ctx.ContactOperationPlaces
           where query.Where(x=> x.Name == c.Contact.Name).Count() > 0
           select c);
     //Now query_2 contains all contactoperationsplaces which have a contact that was found in var query
