    [HttpPost]
    public ActionResult Foo(PersonViewModel personViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var person = Mapper.Map<PersonViewModel, Person>(personViewModel);
        _repository.UpdatePerson(person);
        return RedirectToAction("Success");
    }
