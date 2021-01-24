    public IActionResult Index()
        {
            model objmodel = new model(); // same model return from another project.
            return View("~/WebApplicationModule2/Home/Index.cshtml",objmodel );
        }
