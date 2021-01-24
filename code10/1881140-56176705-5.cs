    var lista = x
        .SelectRows(r =>
            // Extract the row data by name into a flat object
            new
            {
                id = Convert.ToInt32(r["id"], NumberFormatInfo.InvariantInfo),
                id_user = Convert.ToInt32(r["id_user"], NumberFormatInfo.InvariantInfo),
                name = r["name"].ToString(),
                id_user1 = Convert.ToInt32(r["id_user1"], NumberFormatInfo.InvariantInfo),
                name1 = r["name1"].ToString(),
            })
        .Select(r =>
            // Convert the flat object to a `Customer`.
            new Customer
            {
                id = r.id,
                user1 = new User { Id = r.id_user, Name = r.name },
                user2 = new User { Id = r.id_user1, Name = r.name1 },
            })
            .ToList();
