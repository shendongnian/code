    using (var dbContext = new ContentDbContext())
     {
        foreach (var item in parser.GetNextContent())
         {
                string key = item.Key;
                string id = dbContext.Contents.Find(key).ObjectId;
                item.Id = id;
                // Assign other fields...
                yield return item;
            }
        }
