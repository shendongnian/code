       public IList<Thread> ListAll(int forumid)
        {
            var threads =
                from t in db.Threads
                where t.forumid == forumid
                select new 
                        {
                          Thread = t,
                          Count = t.Post.Count,
                          Latest = t.Post.OrderByDescending(p=>p.Date).Select(p=>p.Date).FirstOrDefault()
                        }
        }
