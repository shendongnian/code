    var grid = db.mytable.Where(c => c.Item== "Order").ToList().Select(c => new
                {
                    FirstName = Encryption.Decrypt(c.FirstName),
                    LastName = Encryption.Decrypt(c.LastName),
                    Id = c.Id
                 }).ToList();
