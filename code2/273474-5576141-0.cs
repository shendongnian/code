    [HttpPost]
    public ActionResult ControllerAction(MyViewModel viewModel)
    {
      ModelState.AddRuleViolations(viewModel.GetRuleViolations);
    
      if (!ModelState.IsValid)
      {
        return View();
      }
    
      // Perform repository action (pseudo code to follow)
      _repository.ClearErrorState();
      _repository.DoSomething();
      ModelState.AddRuleViolation(repository.GetRuleViolations());
    
      if (!ModelState.IsValid)
      {
        return View();
      }
    
      return RedirectToAction("Foo","Bar");
    }
    
    class Repository
    {
      List<RuleViolation> _errors = new List<RuleViolation>();
      
      public void ClearErrorState()
      {
        _errors.Clear();
      }
    
      public void DoSomething(...)
      {
         try
         {
           DoSomthingThatFails();
         }
         catch (Exception ex)
         {
           _errors.Add(new RuleViolation(null, "Error while saving customer");
           _errors.Add(new RuleViolation("SSN", "SSN must be unique"); // This one I struggle with as bad design, tying UI element to data elements is bad, so generally I try to prevent everything when checking the viewmodel and only catch general (unforeseen) errors here.
         }
      }
    
      public IEnumerable<RuleViolation> GetRuleViolations()
      {
        return _errors;
      }
    }
