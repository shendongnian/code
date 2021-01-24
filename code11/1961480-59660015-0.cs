    (from a in Customers
    join b in CustomerContacts.Where(p => p.Contact.ContactType.Code == "phone") on a.Id equals b.CustomerId into bb
    from b in bb.DefaultIfEmpty()
    join e in CustomerContacts.Where(p => p.Contact.ContactType.Code == "email") on a.Id equals e.CustomerId into ee
    from e in ee.DefaultIfEmpty()
    join f in Bookings.Where(p => p.EntityId == 4) on a.Id equals f.CustomerId into ff
    from f in ff.DefaultIfEmpty()
    join h in CustomerAddresses on a.Id equals h.CustomerId into hh
    from h in hh.DefaultIfEmpty()
    where
        (b.Contact.Value.Contains("123") || e.Contact.Value.Contains("123"))
        && (a.EntityId == 4 || f != null)
    select new {
        a.Id,
        phone = b.Contact.Value,
        email = e.Contact.Value,
        count = Vehicles.Where(p => p.CustomerId == a.Id).Count(),
        h.Address.State,
        h.Address.Suburb
    }).GroupBy(i => i.Id).ToList();
