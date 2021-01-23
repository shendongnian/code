    // Web layer (Controller)
    public ActionResult Add(AddPersonViewModel viewModel)
    {
        service.AddPerson(viewModel.FirstName, viewModel.LastName)
        // some other stuff...
    }
    // Service layer
    public void AddPerson(string firstName, string lastName)
    {
        var person = new Person { FirstName = firstName, LastName = lastName };
        // some other stuff...
    }
