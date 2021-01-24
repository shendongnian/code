csharp
var inactiveCatIDs = collection.AsQueryable()
                               .Where(p => p.DateUpdated <= DateTime.UtcNow.AddDays(-1))
                               .Select(p => p.CategoryID)
                               .ToArray();
collection.UpdateMany(c => inactiveCatIDs.Contains(c.ID),
                      Builders<ProductCategory>.Update.Set(c => c.Active, false));
here's a test program:
