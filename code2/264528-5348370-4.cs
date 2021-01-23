    public ActionResult action()
    {
        SentModel model = new SentModel(); 
        return View(SentModel); //i believe typeof(SentModel) != typeof(AcceptedModel) that is what is causing problem
    }
