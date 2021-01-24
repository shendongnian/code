    public async Task<IActionResult> Foo(MyViewModel vm)
    {
      if (!ModelState.IsValid) return View(vm);
    
      var filter = new FilterObject(vm);
      var firstTask = _firstContext.YourQueryable.ToListAsync();
      var secondTask = _secondContext.YourQueryable.ToListAsync();    
      var firstResult = await firstTask;
      var secondResult = await secondTask;
    
      vm.Result.Clear();
      vm.Results.AddRange(firstResult);
      vm.Results.AddRange(secondResult);
    
      return View("Index", vm);
    }
