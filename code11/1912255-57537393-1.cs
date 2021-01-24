    public ActionResult Index()
    {
        var mainModel = context.Person.Join(context.Car, p => p.personID, c => c.IdPerson, (p, c) => new PersonCar { PersonId = p.personID, PersonName = p.Name, CarId = c.carID, CarName = c.Name }).ToList();
        return View(mainModel);
    }
