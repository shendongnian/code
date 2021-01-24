    public ActionResult SomeAction(TheModel model)
    {
        if (model.Usage == 2)
        {
            if (model.Quantity == null) // quantity is changed to nullable
            {
                ModelState.AddModelError("Quantity", "Value is required for this usage");
            }
        }
        ....
        if (ModelState.IsValid)
        {
            ...
        }
        else
        {
            return View(model); // there are validation errors
        }
    }
