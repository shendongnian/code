    var data = from c in _context.Posts
                       join p in _context.PostViewCount on c.Id equals p.PostId
                       select new PostsModel
                       {
                           Count = p.Count,
                           Title = c.Title,
                           // etc...
                       };
            var dat = data.OrderByDescending(x=>x.Count).ToList();
            ViewBag.data2 = dat;
