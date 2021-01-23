    var query = from d in entities.dealerships
                from l in entities.locations.Where(loc => loc.DealershipID == d.ID).DefaultIfEmpty()
                from c in entities.contacts.Where(cont => cont.LocationID == l.ID).DefaultIfEmpty()
                where d.Keywords.Contains(keywords) || l.Keywords.Contains(keywords) || l.Sells.Contains(keywords) || c.Keywords.Contains(keywords)
                select new
                {
                    Dealership = d,
                    Location = l,
                    Contact = c
                };
    var results = (from r in query.AsEnumerable()
                   select new
                   {
                       Name = r.Dealership.Name,
                       Website = r.Dealership.Website,
                       Contact = r.Contact.FirstName + " " + r.Contact.LastName,
                       Address = r.Location.Address + ", " + r.Location.City + ", " + r.Location.State + " " + r.Location.Zip,
                       WorkPhone = r.Contact.WorkPhone,
                       CellPhone = r.Contact.CellPhone,
                       Fax = r.Contact.Fax,
                       Email = r.Contact.Email,
                       AltEmail = r.Contact.AltEmail,
                       Sells = r.Location.Sells
                   }).ToList();
    bindingSource.DataSource = results;
