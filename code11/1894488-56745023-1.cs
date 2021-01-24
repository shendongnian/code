         public IActionResult Index(List<Area> area)
        {
            if (areas.Count == 0)
            {
                addData();
            }
            return View(areas);
        }
    In your view, if are using strong typed view, surround your inputs and fields with this:
    if(Model != null)
    {
     //Yours form, fields and inputs here.
    }
