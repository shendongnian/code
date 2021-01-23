    using (var context = new MyEntities())
    {
        var x = (                    
            from a in context.ModelSetA.Include("ModelB")
            join c in context.ModelSetC on a.Id equals c.Id
            join d in context.ModelSetD on a.Id equals d.Id
            select new { a, b, c }).FirstOrDefault();
    
        if (x == null)
            return null;
    
        return new MyModelA()
            {
                Id = x.a.Id,
                Name = x.a.Name,
                ModelB = new MyModelB() { Id = x.a.ModelB.Id, Name = x.a.ModelB..Name },
                ModelC = new MyModelC() { Id = x.c.Id, Name = x.c.Name },
                ModelD = new MyModelD() { Id = x.d.Id, Name = x.d.Name }
            };
    }
