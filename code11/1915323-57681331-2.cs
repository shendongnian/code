    public ActionResult Test(LansingMileageViewModel model)
    {
        DateTime selectedDate = model.ExpMonthYrInput;
    
        return View(model);
    }
