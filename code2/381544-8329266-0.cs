    public ActionResult FooDetails(string id)
    {
        using(var session = this.documentStore.OpenSession())
        {
            var foo = session.Load<Foo>(id).Include(....);
            var alpha = session.Load<Alpha>(foo.AlphaId);
            var beta = session.Load<Beta>(foo.BetaId);
            
            // null checks
            var fooViewModel = Mapper.Map<FooViewModel>(foo);
            fooViewModel.Alpha = Mapper.Map<AlphaViewModel>(alpha);
            fooViewModel.Beta = Mapper.Map<BetaViewModel>(beta);
            return View(fooViewModel);
        }
    }  
