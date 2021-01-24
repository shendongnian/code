     public IActionResult Settings()
        {
           var array = Configuration.GetSection("Locations:Location")
               .GetChildren()
               .Select(configSection => configSection.Value);
           return View();
        }
