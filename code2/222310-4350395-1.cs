    var query = db.Brands
                  .AsEnumerable()
                  .Select(p => new {
            Brand = p,
            p.Description.Length < 204 ? p.Description 
                                       : p.Description.Substring(0, 204) + "..."
        });
