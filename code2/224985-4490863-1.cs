    [HttpPost]
    public ActionResult Create(ComplexModel mainModel, SimpleModel nestedModel, SimpleModel2 nested2Model)
    {
        if (ModelState.IsValid)
        {
            var main = mainModel;
            var nested1 = nestedModel;
            var nested2 = nested2Model;
        }
    
        return View();
    }
