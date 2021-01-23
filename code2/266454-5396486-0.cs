    public ActionResult SomeAction(...) 
    {
        _repository.DoSomething();
        ...
        _repository.DoSomethingElse();
        ...
        _repository.SaveChanges();
        return View(...);
    }
