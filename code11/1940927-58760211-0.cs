csharp
var res = collection.AsQueryable()
                    .Where(t => t.Id == session.Id)
                    .Join(
                        foreignColl.AsQueryable(), // foreign collection
                        s => s.TaskId,             // local field
                        c => c.Id,                 // foreign field
                        (s, c) => new TestSession  // projection
                        {
                            Id = s.Id,
                            Name = s.Name,
                            TaskId = s.TaskId,
                            Task = c
                        })
                    .Single();
here's the full program i used for testing:
