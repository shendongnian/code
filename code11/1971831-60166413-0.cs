     var query1= from u in _context.Set<YOURCONTEXT>().Where(x => x.Authenticated)
                        from p in _context.Set<YOURCONTEXT>()Where(x => x.Visible)
              select new { u,p, };
            var model = query1.Select(t => new SomeViewModel
            {
                Users = t.u.WHATEVER,
                Schools = t.p.WHATEVER,
               
             
            });
            return View(await model.ToListAsync());
