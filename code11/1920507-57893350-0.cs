    public async Task<IActionResult> Foo(MyViewModel vm)
    {
      if (!ModelState.IsValid) return Task.Run(()=> (IActionResult)View(vm));
      
      var filter = new FilterObject(vm);
      
      //This will execute the queries
      var firstTask = _firstContext.FilterItems(filter).ToListAsync();
      var secondTask = _secondContext.FilterItems(filter).ToListAsync();
      
      vm.Result.Clear();
      vm.Results.AddRange(await firstTask); //add the first set when they're available
      vm.Results.AddRange(await secondTask); //add the second set when they're available
      return View("Index", vm);
    }
