    public ActionResult Index()
    {
        var model = new SliderViewModel
        {
            Items = new[]
            {
                new Item { Value = "Poor", Text = "Poor" },
                new Item { Value = "Good", Text = "Good" },
                new Item { Value = "Med", Text = "Med" },
                new Item { Value = "VeryGood", Text = "VeryGood" },
                new Item { Value = "Excellent", Text = "Excellent" }
            }
        };
        return View(model);
    }
