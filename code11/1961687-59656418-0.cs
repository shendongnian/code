    var filteredTable = db.mytable.Where(c => c.Item== "Order").ToList();
    var grid = filteredTable .Select(c => new
                {
                    FirstName = Encryption.Decrypt(c.FirstName),
                    LastName = Encryption.Decrypt(c.LastName),
                    Id = c.Id
                 }).ToList();
