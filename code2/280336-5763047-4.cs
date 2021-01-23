    [RequiresRouteValues("first.Id")] // when you provide prefix with your form
    // or
    [RequiresRouteValues("Some.ContractType1.Distict.Property.Name")]
    public ActionResult Process(ContractType1 first)
    {
        // do what's appropriate
    }
    
    [RequiresRouteValues("second.Id")] // when you provide prefix with your form
    // or
    [RequiresRouteValues("Some.ContractType2.Distict.Property.Name")]
    public ActionResult Process(ContractType2 second)
    {
        // do what's appropriate
    }
