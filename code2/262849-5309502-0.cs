    var query = from u in _db.Repository<User>()
                where !u.IsDeleted
                group u by u.UserId into g
                select new UserWithMessageCount {
                   User = g.First(x => x.UserId == g.Key),
                   MessageCount = g.Count(x => x.Messages.Count())
                }
