    public ActionResult Foo()
    {
        var person = _repository.GetPerson();
        var personViewModel = Mapper.Map<Person, PersonViewModel>(person);
        return View(personViewModel);
    }
