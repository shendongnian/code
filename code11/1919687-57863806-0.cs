    public IActionResult Get()
    {
        if (this.Request.Browser == "Chrome")
        {
            return View("ViewForChrome");
        }
        else
        {
            return View("OtherView");
        }
    }
