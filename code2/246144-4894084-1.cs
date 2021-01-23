    public ViewResult Food(int id)
    {
        var food = ...
        if (/* determine if food is Veg or Fruit */)
            return View("Fruit", new FruitViewModel { ... });
        else
            return View("Veg", new VegViewModel { ... });
    }
