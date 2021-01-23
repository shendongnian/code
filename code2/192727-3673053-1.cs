    [DateSelector]
    public ActionResult List(DateTime date)
    {
        this.ViewData.Model = date;
        return this.View();
    }
