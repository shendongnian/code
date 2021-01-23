    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Editor(ModelTest modelTest)
    {
        ModelState.Remove("MyValue");
        modelTest.MyValue += " Post!";
        return View(modelTest);
    }
