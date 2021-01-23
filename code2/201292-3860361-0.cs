var results = (from d in entities.dealerships
              join l in entities.locations on d.ID equals l.DealershipID
              join c in entities.contacts on l.ID equals c.LocationID
              select new
              {
                  Name = d.Name,
                  Website = d.Website,
                  Address = l.Address + ", " + l.City + ", " + l.State + " " + l.Zip,
                  Contact = c.FirstName + " " + c.LastName,
                  WorkPhone = c.WorkPhone,
                  CellPhone = c.CellPhone,
                  HomePhone = c.HomePhone,
                  Email = c.Email,
                  AltEmail = c.AltEmail,
                  Sells = l.Sells
               }).ToList();
