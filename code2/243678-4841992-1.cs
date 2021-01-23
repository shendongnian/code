    public ActionResult Filter(EntityFilterViewModel model) 
    {
         var result = from e in _entityRepository.Entites
                      where e.PowerPlanet.Equals(model.PowerPlanet) &&
                            e.GeneratingUnits.Equals(model.GeneratingUnits) &&
                            e.Periond.Equals(model.Period)
                            // other filters you would want...
         return View("List", result); // use the overload which takes a view name and a viewmodel object
    }
