    public ActionResult GetMeals()
    {
        var meals = DataContext.GetMeals().ToList(); // <-- being eager with .ToList()
        var units = DataContext.GetUnits().ToList(); // <-- being eager with .ToList()
        var viewModel = meals.Select(meal => new MealViewModel
        {
            MealDescription = meal.Description,
            SelectedUnit = meal.UnitId,
            Units = units.Select(unit => new SelectListItem
            {
                Value = unit.Id.ToString(),
                Text = unit.Name
            })
        });
        return PartialView("_Meals", viewModel);
    }
