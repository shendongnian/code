    public ActionResult SaveProfile(FormCollection form)
    {
        var servicesFor = (form["services-for"] ?? "")
            .Split(',')
            .Select(int.Parse);
        // ...
    }
